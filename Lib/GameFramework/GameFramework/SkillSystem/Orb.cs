using System;
using System.Collections.Generic;
using GameFramework.Base;
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
        private ISkillCaster m_SkillCaster;
        private IOrbCaster m_OrbCaster;
        private List<IOrbMotion> m_Motions = new List<IOrbMotion>();
        private List<IOrbAction> m_TriggerActions = new List<IOrbAction>();
        private List<IOrbAction> m_CreateActions = new List<IOrbAction>();
        private List<IOrbAction> m_DestroyActions = new List<IOrbAction>();

        /// <summary>
        /// 技能释放者
        /// </summary>
        public ISkillCaster SkillCaster
        {
            get
            {
                return m_SkillCaster;
            }
            private set
            {
                m_SkillCaster = value;
            }
        }
        /// <summary>
        /// 法球释放者
        /// </summary>
        public IOrbCaster OrbCaster
        {
            get
            {
                return m_OrbCaster;
            }
            private set
            {
                m_OrbCaster = value;
            }
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
