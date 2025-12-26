using CMFramework.Core;
using CMFramework.Core.Collections;
using System;
using System.Collections.Generic;
using Unity.Entities;
using static CMFramework.ECS.ECSWorld;

namespace CMFramework.ECS
{
    public class ECSWorld
    {
        public class ComponentInfo
        {
            private SparseSet set = new SparseSet(32);

            public void AddEntity(int e) => set.Add(e);
            public void RemoveEntity(int e) => set.Remove(e);
        }

        public class Commands
        {
            private ECSWorld m_world;

            public Commands(ECSWorld world)
            {
                m_world = world; 
            }
             
            public Commands Spawn<ComponentType>(Action<BaseComponent> ctor = null) where ComponentType : BaseComponent, new()
            {
                int entity = IDGenerator.Get();
                DoSpawn<ComponentType>(entity, ctor);
                return this;
            }
            public Commands Spawn<ComponentType>(int entity, Action<BaseComponent> ctor = null) 
                where ComponentType : BaseComponent, new()
            {
                DoSpawn<ComponentType>(entity, ctor);
                return this;
            }

            public Commands Remove(int entity)
            {
                Dictionary<int, BaseComponent> dic_idx_component;
                if(m_world.dic_entity_componentContainer.TryGetValue(entity, out dic_idx_component))
                {
                    foreach (var item in dic_idx_component)
                    {
                        m_world.dic_componentID_componentInfo[item.Key].RemoveEntity(entity);
                        ReferencePool.Return<BaseComponent>(item.Value.idx);
                    }
                    m_world.dic_entity_componentContainer.Remove(entity);
                }

                return this;
            }

            private void DoSpawn<ComponentType>(int entity, Action<ComponentType> ctor = null) where ComponentType : BaseComponent, new()
            {
                int idx = IdxGetter.Get<ComponentType>();
                ComponentInfo info = null;
                if (!m_world.dic_componentID_componentInfo.TryGetValue(idx, out info))
                {
                    info = new ComponentInfo();
                    m_world.dic_componentID_componentInfo[idx] = info;
                    ObjectPoolCtorData<ComponentType> ctorData = new ObjectPoolCtorData<ComponentType>(typeof(ComponentType).Name, 32, ()=> { return new ComponentType(); }, true, ctor);
                    ReferencePool.GetPool(ctorData);
                }

                info.AddEntity(entity);

                Dictionary<int, BaseComponent> dic_idx_component = null;
                if (!m_world.dic_entity_componentContainer.TryGetValue(entity, out dic_idx_component))
                {
                    dic_idx_component = new();
                    m_world.dic_entity_componentContainer.Add(entity, dic_idx_component);
                }

                dic_idx_component[idx] = ReferencePool.GetRef<ComponentType>();
            }
        }

        private Dictionary<int, ComponentInfo> dic_componentID_componentInfo = new();
        private Dictionary<int, Dictionary<int, BaseComponent>> dic_entity_componentContainer = new();


    }
}

