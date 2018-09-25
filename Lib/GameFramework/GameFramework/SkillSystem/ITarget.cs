
using GameFramework.Base;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 目标，可作为目标的
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// 目标位置
        /// </summary>
        Vector3 position { get; set; }
    }
}
