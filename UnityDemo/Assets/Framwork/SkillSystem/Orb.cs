using System;
using System.Collections.Generic;
#if UNITY_PLATFORM
using Vector3 = UnityEngine.Vector3;
#else
using Vector3 = GameFramework.Base.Vector3;
#endif
using GameFramework.FactorySystem;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 法球
    /// </summary>
    public class Orb : IOrb, IOrbCaster
    {
#region Interface
#region interface ITarget
        public Vector3 Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public Vector3 Scale
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public Vector3 EulerAngles
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
#endregion
#region IOrb
        public void Trigger(E_OrbEventType p_EventType, params object[] p_Param)
        {
            switch (p_EventType)
            {
                case E_OrbEventType.Orb_AutoDestroy:
                    {
                        IsExpire = true;

                        for (int i = 0; i < DestroyActions.Count; i++)
                        {
                            DestroyActions[i].Trigger();
                        }

                        break;
                    }
                case E_OrbEventType.Orb_Trigger:
                    {
                        IsExpire = true;
                        for (int i = 0; i < TriggerActions.Count; i++)
                        {
                            TriggerActions[i].Trigger();
                        }
                        break;
                    }
            }
        }
#endregion
#endregion
#region Property
#endregion

        private List<IOrbMotion> m_Motions = new List<IOrbMotion>();
        private List<IOrbAction> m_TriggerActions = new List<IOrbAction>();
        private List<IOrbAction> m_CreateActions = new List<IOrbAction>();
        private List<IOrbAction> m_DestroyActions = new List<IOrbAction>();
        private List<IOrbTrigger> m_Triggers = new List<IOrbTrigger>();

        /// <summary>
        /// 技能释放者
        /// </summary>
        public ISkillCaster SkillCaster
        {
            get;
            private set;
        }
        /// <summary>
        /// 法球释放者
        /// </summary>
        public IOrbCaster OrbCaster
        {
            get;
            private set;
        }
        /// <summary>
        /// orb target,(1 orb->1 target)
        /// </summary>
        public IOrbTarget OrbTarget
        {
            get;
            private set;
        }
        /// <summary>
        /// 法球的运动
        /// </summary>
        public List<IOrbMotion> Motions { get { return m_Motions; } }
        /// <summary>
        /// 法球触发是行为
        /// </summary>
        public List<IOrbAction> TriggerActions { get { return m_TriggerActions; } }
        /// <summary>
        /// 法球创建时行为
        /// </summary>
        public List<IOrbAction> CreateActions { get { return m_CreateActions; } }
        /// <summary>
        /// 销毁时出发的行为
        /// </summary>
        public List<IOrbAction> DestroyActions { get { return m_DestroyActions; } }
        /// <summary>
        /// triggers
        /// </summary>
        public List<IOrbTrigger> Triggers { get { return m_Triggers; } }
        /// <summary>
        /// 当前发球是否已经失效
        /// </summary>
        public bool IsExpire { get; private set; }
        #region Entity_Factory
        private static Factory<OrbAction> acFactory = new Factory<OrbAction>();
        private static Factory<OrbTrigger> tgFactory = new Factory<OrbTrigger>();
        private static Factory<OrbMotion> moFactory = new Factory<OrbMotion>();
        /// <summary>
        /// rigister action factory
        /// </summary>
        /// <param name="p_Key"></param>
        /// <param name="p_Type"></param>
        public static void RigisterAction(int p_Key,Type p_Type)
        {
            acFactory.Rigister(p_Key, p_Type);
        }
        /// <summary>
        /// create action
        /// </summary>
        /// <param name="p_Data"></param>
        /// <returns></returns>
        private static OrbAction CreateAction(OrbActionData p_Data)
        {
            OrbAction ac = acFactory.Create(p_Data.type);
            ac.Deserialize(p_Data);
            return ac;
        }
        /// <summary>
        /// rigister motion factory
        /// </summary>
        /// <param name="p_Key"></param>
        /// <param name="p_Type"></param>
        public static void RigisterMotion(int p_Key, Type p_Type)
        {
            moFactory.Rigister(p_Key, p_Type);
        }
        /// <summary>
        /// create motion
        /// </summary>
        /// <param name="p_Data"></param>
        /// <returns></returns>
        private static OrbMotion CreateMotion(OrbMotionData p_Data)
        {
            OrbMotion mo = moFactory.Create(p_Data.type);
            mo.Deserialize(p_Data);
            return mo;
        }
        /// <summary>
        /// rigister trigger factory
        /// </summary>
        /// <param name="p_Key"></param>
        /// <param name="p_Type"></param>
        public static void RigisterTrigger(int p_Key, Type p_Type)
        {
            tgFactory.Rigister(p_Key, p_Type);
        }
        /// <summary>
        /// create trigger
        /// </summary>
        /// <param name="p_Data"></param>
        /// <returns></returns>
        private static OrbTrigger CreateTrigger(OrbTriggerData p_Data)
        {
            OrbTrigger tg = tgFactory.Create(p_Data.type);
            tg.Deserialize(p_Data);
            return tg;
        }
        #endregion
        /// <summary>
        /// Create orb instance
        /// </summary>
        /// <param name="p_SkillCaster"></param>
        /// <param name="p_OrbCaster"></param>
        /// <param name="p_OrbTarget"></param>
        /// <param name="p_OrbData"></param>
        /// <returns></returns>
        public static Orb Instantiate(ISkillCaster p_SkillCaster, IOrbCaster p_OrbCaster, IOrbTarget p_OrbTarget, OrbData p_OrbData)
        {
            Orb _orb = new Orb();
            _orb.SkillCaster = p_SkillCaster;
            _orb.OrbCaster = p_OrbCaster;
            _orb.OrbTarget = p_OrbTarget;
            #region Init action motion trigger
            for (int i = 0; i < p_OrbData.createActions.Length; i++)
            {
                OrbAction ac = CreateAction(p_OrbData.createActions[i]);
                _orb.CreateActions.Add(ac);
            }
            for (int i = 0; i < p_OrbData.triggerActions.Length; i++)
            {
                OrbAction ac = CreateAction(p_OrbData.triggerActions[i]);
                _orb.TriggerActions.Add(ac);
            }
            for (int i = 0; i < p_OrbData.destroyActions.Length; i++)
            {
                OrbAction ac = CreateAction(p_OrbData.destroyActions[i]);
                _orb.DestroyActions.Add(ac);
            }
            for (int i = 0; i < p_OrbData.createActions.Length; i++)
            {
                OrbMotion mo = CreateMotion(p_OrbData.motions[i]);
                _orb.Motions.Add(mo);
            }
            #endregion


            return _orb;
        }

        /// <summary>
        /// orb update
        /// </summary>
        /// <param name="p_ElapsedSec"></param>
        public void Tick(float p_ElapsedSec)
        {
            if (IsExpire)
            {
                return;
            }
            //update motion
            for (int i = 0; i < Motions.Count; i++)
            {
                Motions[i].Tick(p_ElapsedSec);
            }
            //update trigger
            for (int i = 0; i < Triggers.Count; i++)
            {
                Triggers[i].Tick(p_ElapsedSec);
            }
        }
    }
}
