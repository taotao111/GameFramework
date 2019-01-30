#if UNITY_DLL
using Vector3 = UnityEngine.Vector3;
#else
using Vector3 = GameFramework.Base.Vector3;
#endif

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
        Vector3 Position { get; set; }
        /// <summary>
        /// 目标角度
        /// </summary>
        Vector3 EulerAngles { get; set; }
        /// <summary>
        /// 目标缩放
        /// </summary>
        Vector3 Scale { get; set; }
        
    }
}
