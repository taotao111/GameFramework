using System.Collections.Generic;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// search orb target
    /// </summary>
    public interface IOrbTargetSearch
    {
        /// <summary>
        /// a orb only one orb target
        /// but you search mutil targets to create mutil orbs
        /// </summary>
        /// <returns></returns>
        List<IOrbTarget> Search();
    }
}
