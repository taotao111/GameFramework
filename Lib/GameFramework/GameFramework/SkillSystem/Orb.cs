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
        public Vector3 position
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
        public void Trigger()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        private ISkillCaster m_SkillCaster;
        private IOrbCaster m_OrbCaster;
        private List<IOrbMotion> m_Motions = new List<IOrbMotion>();
        private List<IOrbAction> m_TriggerActions = new List<IOrbAction>();
        private List<IOrbAction> m_CreateActions = new List<IOrbAction>();

        /// <summary>
        /// 技能释放者
        /// </summary>
        public ISkillCaster skillCaster
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
        public IOrbCaster orbCaster
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
        public List<IOrbMotion> motions { get { return m_Motions; } }
        /// <summary>
        /// 法球触发是行为
        /// </summary>
        public List<IOrbAction> triggerActions { get { return m_TriggerActions; } }
        /// <summary>
        /// 法球创建时行为
        /// </summary>
        public List<IOrbAction> createActions { get { return m_CreateActions; } }



        public void Tick(float p_ElapsedSec)
        {
            for (int i = 0; i < motions.Count; i++)
            {
                motions[i].Tick(p_ElapsedSec);
            }
        }
    }
}
