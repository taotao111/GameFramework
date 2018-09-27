using System;

namespace GameFramework.SkillSystem
{
    public class OrbMotion : IOrbMotion
    {
        public uint id;
        public string name;

        /// <summary>
        /// 持有者
        /// </summary>
        public IOrb Holder
        {
            get;
            set;
        }

        /// <summary>
        /// 刷新按照具体的运动方式自己刷新
        /// </summary>
        /// <param name="p_elapsedSec"></param>
        public virtual void Tick(float p_elapsedSec)
        {
            throw new NotImplementedException();
        }


        public virtual void Deserialize(OrbMotionData p_data)
        {
            this.id = p_data.id;
            this.name = p_data.name;
        }

         
        public virtual OrbMotionData Serialize(OrbMotionData p_data)
        {
            return null;
        }
    }
}
