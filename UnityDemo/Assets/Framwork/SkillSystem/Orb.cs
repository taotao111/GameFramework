using System;
using System.Collections.Generic;
#if UNITY_PLATFORM
using Vector3 = UnityEngine.Vector3;
#else
using Vector3 = GameFramework.Base.Vector3;
#endif


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
        /// 当前发球是否已经失效
        /// </summary>
        public bool IsExpire { get; private set; }
        #region
        private static Factory<OrbAction> acFactory = new Factory<OrbAction>();
        private static Factory<OrbTrigger> tgFactory = new Factory<OrbTrigger>();
        private static Factory<OrbMotion> moFactory = new Factory<OrbMotion>();
        public static void RigisterAction(int p_Key,Type p_Type)
        {
            acFactory.Rigister(p_Key, p_Type);
        }
        public static void RigisterMotion(int p_Key, Type p_Type)
        {
            moFactory.Rigister(p_Key, p_Type);
        }
        public static void RigisterTrigger(int p_Key, Type p_Type)
        {
            tgFactory.Rigister(p_Key, p_Type);
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

            for (int i = 0; i < p_OrbData.createActions.Length; i++)
            {
                OrbAction ac = acFactory.Create(p_OrbData.createActions[i].type);
                ac.Deserialize(p_OrbData.createActions[i]);
                _orb.CreateActions.Add(ac);
            }

            return _orb;
        }


        public void Tick(float p_ElapsedSec)
        {
            if (IsExpire)
            {
                return;
            }
            for (int i = 0; i < Motions.Count; i++)
            {
                Motions[i].Tick(p_ElapsedSec);
            }
        }
    }
}
