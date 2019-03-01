using System.Collections.Generic;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// get the orb target.
    /// </summary>
    public abstract class OrbTargetSearch : IOrbTargetSearch
    {
        /// <summary>
        /// a orb only one orb target
        /// but you search mutil targets to create mutil orbs
        /// </summary>
        /// <returns></returns>
        public abstract List<IOrbTarget> Search();
    }
}
