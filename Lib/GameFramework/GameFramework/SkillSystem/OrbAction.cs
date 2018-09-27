using System;

namespace GameFramework.SkillSystem
{
    public class OrbAction : IOrbAction
    {
        /// <summary>
        /// 持有者
        /// </summary>
        public IOrb Holder
        {
            get;
            set;
        }

        public void Trigger()
        {
            throw new NotImplementedException();
        }
    }
}
