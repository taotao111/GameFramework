using System;

namespace GameFramework.SkillSystem
{
    public class OrbAction : IOrbAction
    {
        /// <summary>
        /// which orb owner this.
        /// </summary>
        public IOrb Holder
        {
            get;
            set;
        }
        /// <summary>
        /// trigger action
        /// </summary>
        public void Trigger()
        {
            throw new NotImplementedException();
        }
    }
}
