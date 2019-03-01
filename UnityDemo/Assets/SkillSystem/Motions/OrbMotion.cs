using System;

namespace GameFramework.SkillSystem
{
    public class OrbMotion : IOrbMotion
    {
        public uint id;
        public string name;

        /// <summary>
        /// which the orb own this motion
        /// </summary>
        public IOrb Holder
        {
            get;
            set;
        }

        /// <summary>
        /// update motion
        /// </summary>
        /// <param name="p_elapsedSec"></param>
        public virtual void Tick(float p_elapsedSec)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// data->entity
        /// </summary>
        /// <param name="p_data"></param>
        public virtual void Deserialize(OrbMotionData p_data)
        {
            this.id = p_data.id;
            this.name = p_data.name;
        }

        /// <summary>
        /// entity->data,
        /// </summary>
        /// <param name="p_data"></param>
        /// <returns></returns>
        public virtual OrbMotionData Serialize(OrbMotionData p_data)
        {
            return null;
        }
    }
}
