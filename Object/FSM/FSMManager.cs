using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMFramework.Core
{
    public class FSMManager : ManagerBase
    {
        private Dictionary<Type, FSMBase> dic_type_fsm;

        public override void Init()
        {
            dic_type_fsm = new();
        }

        /// <summary>
        /// 返回一个状态机，状态机如果不存在则会返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public FSM<T> GetFSM<T>() where T : class
        {
            Type type = typeof(T);
            FSMBase fsm = null;
            if (dic_type_fsm.TryGetValue(type, out fsm))
                return (FSM<T>)fsm;

            return null;
        }

        /// <summary>
        /// 返回一个状态机，如果状态机不存在则会自动创建一个返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="list_state"></param>
        /// <returns></returns>
        public FSM<T> GetFSM<T>(string name, List<FSMState<T>> list_state) where T : class
        {
            FSM<T> fsm = GetFSM<T>();
            if (fsm == null)
                fsm = CreateFSM<T>(name, list_state);

            return fsm;
        }

        public FSM<T> CreateFSM<T>(string name, List<FSMState<T>> list_state) where T : class
        {
            FSM<T> fsm = FSM<T>.Create(name, list_state);
            dic_type_fsm[typeof(T)] = fsm;

            return fsm;
        }
    }
}

