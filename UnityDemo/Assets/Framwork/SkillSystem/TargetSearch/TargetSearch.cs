using System.Collections.Generic;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// get the orb target.
    /// </summary>
    public abstract class TargetSearch : ITargetSearch
    {
        /// <summary>
        /// a orb only one orb target
        /// but you search mutil targets to create mutil orbs
        /// </summary>
        /// <returns></returns>
        public abstract List<ITarget> Search();
        /// <summary>
        /// data->entity
        /// </summary>
        /// <param name="p_data"></param>
        public virtual void Deserialize(TargetData p_data)
        {
        }

        /// <summary>
        /// entity->data,
        /// </summary>
        /// <param name="p_data"></param>
        /// <returns></returns>
        public virtual TargetData Serialize(TargetData p_data)
        {
            return null;
        }
    }
}
