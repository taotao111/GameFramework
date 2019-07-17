using System;

namespace GameFramework.SkillSystem
{
    public class OrbMotion : IOrbMotion
    {
        public uint id;
        public int type;
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
        /// <param name="p_ElapsedSec"></param>
        public virtual void Tick(float p_ElapsedSec)
        {
            
        }

        /// <summary>
        /// data->entity
        /// </summary>
        /// <param name="p_Data"></param>
        public virtual void Deserialize(OrbMotionData p_Data)
        {
            this.id = p_Data.id;
            this.name = p_Data.name;
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
