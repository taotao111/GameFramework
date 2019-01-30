

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 法球触发行为的触发器
    /// </summary>
    public interface IOrbTrigger
    {
        void Tick(float p_ElapsedSec);
        void Trigger();
    }
}
