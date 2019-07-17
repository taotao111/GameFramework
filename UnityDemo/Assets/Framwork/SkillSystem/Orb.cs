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
                return Transform.position;
            }

            set
            {
                Transform.position = value;
            }
        }
        public Vector3 Scale
        {
            get
            {
                return Transform.localScale;
            }

            set
            {
                Transform.localScale = value;
            }
        }
        public Vector3 EulerAngles
        {
            get
            {
                return Transform.eulerAngles;
            }

            set
            {
                Transform.eulerAngles = value;
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

        public UnityEngine.GameObject GameObject { get;private set; }
        public UnityEngine.Transform Transform { get; private set; }

        public Orb(OrbData p_OrbData)
        {
            GameObject = Helper.NewGameObject(string.IsNullOrEmpty(p_OrbData.name) ? p_OrbData.id.ToString() : p_OrbData.name);
            Transform = GameObject.transform;
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
        public void TriggerCreate()
        {
            for (int i = 0; i < CreateActions.Count; i++)
            {
                CreateActions[i].Trigger();
            }
        }
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
            Orb _orb = new Orb(p_OrbData);
            //Init some data
            _orb.SkillCaster = p_SkillCaster;
            _orb.OrbCaster = p_OrbCaster;
            _orb.OrbTarget = p_OrbTarget;

            #region Init action motion trigger
            if (p_OrbData.createActions != null)
            {
                for (int i = 0; i < p_OrbData.createActions.Length; i++)
                {
                    OrbAction ac = SkillFactory.CreateAction(p_OrbData.createActions[i]);
                    ac.Holder = _orb;
                    _orb.CreateActions.Add(ac);
                }
            }
            if (p_OrbData.triggerActions != null)
            {
                for (int i = 0; i < p_OrbData.triggerActions.Length; i++)
                {
                    OrbAction ac = SkillFactory.CreateAction(p_OrbData.triggerActions[i]);
                    ac.Holder = _orb;
                    _orb.TriggerActions.Add(ac);
                }
            }
            if (p_OrbData.destroyActions != null)
            {
                for (int i = 0; i < p_OrbData.destroyActions.Length; i++)
                {
                    OrbAction ac = SkillFactory.CreateAction(p_OrbData.destroyActions[i]);
                    ac.Holder = _orb;
                    _orb.DestroyActions.Add(ac);
                }
            }
            if (p_OrbData.motions != null)
            {
                for (int i = 0; i < p_OrbData.motions.Length; i++)
                {
                    OrbMotion mo = SkillFactory.CreateMotion(p_OrbData.motions[i]);
                    mo.Holder = _orb;
                    _orb.Motions.Add(mo);
                }
            }
            #endregion

            _orb.TriggerCreate();
            return _orb;
        }
    }
}
