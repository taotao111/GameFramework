using Vector3 = GameFramework.Base.Vector3;
namespace GameFramework.SkillSystem
{
    public class Target : ITarget
    {
        public Vector3 Position { get; set; }
        public Vector3 EulerAngles { get; set; }
        public Vector3 Scale { get; set; }
    }
}
