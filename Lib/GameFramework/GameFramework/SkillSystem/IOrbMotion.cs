

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 法球的运动
    /// </summary>
    public interface IOrbMotion
    {
        /// <summary>
        /// 运动的更新
        /// </summary>
        /// <param name="p_ElapsedSec"></param>
        void Tick(float p_ElapsedSec);
    }
}
