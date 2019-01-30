#if UNITY_DLL
using Vector3 = UnityEngine.Vector3;
#else
using Vector3 = GameFramework.Base.Vector3;
#endif
namespace GameFramework.SkillSystem
{
    public class Target : ITarget
    {
        public Vector3 Position { get; set; }
        public Vector3 EulerAngles { get; set; }
        public Vector3 Scale { get; set; }
    }
}
