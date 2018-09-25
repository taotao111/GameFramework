using System;

namespace GameFramework.SkillSystem
{
    public class OrbMotion : IOrbMotion
    {
        /// <summary>
        /// 刷新按照具体的运动方式自己刷新
        /// </summary>
        /// <param name="p_elapsedSec"></param>
        public virtual void Tick(float p_elapsedSec)
        {
            throw new NotImplementedException();
        }
    }
}
