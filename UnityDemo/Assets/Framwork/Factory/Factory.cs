using System;
using System.Collections;
using System.Collections.Generic;
namespace GameFramework.FactorySystem
{
    public class Factory : IFactory
    {
        protected Dictionary<int, Type> dic = new Dictionary<int, Type>();
        public virtual object Create(int p_Key)
        {
            if (!dic.ContainsKey(p_Key))
            {
                Debug.LogError("key not exist!");
            }
            return Activator.CreateInstance(dic[p_Key]);
        }

        public virtual void Rigister(int p_Key, Type p_Type)
        {
            if (dic.ContainsKey(p_Key))
            {
                Debug.LogError("key exist!");
            }
            dic.Add(p_Key, p_Type);
        }
    }
    public class Factory<T> : Factory
    {
        public new T Create(int p_Key)
        {
            if (!dic.ContainsKey(p_Key))
            {
                Debug.LogError("key not exist!");
            }

            return (T)base.Create(p_Key);
        }

        //object IFactory.Create(int p_Key)
        //{
        //    if (!dic.ContainsKey(p_Key))
        //    {
        //        Debug.LogError("key not exist!");
        //    }
        //    return Activator.CreateInstance(dic[p_Key]);
        //}
    }
}