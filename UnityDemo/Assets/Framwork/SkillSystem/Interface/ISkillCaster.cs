

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 技能释放者
    /// 技能释放者可以作为技能目标
    /// </summary>
    public interface ISkillCaster : ISkillTarget
    {
        void CastSkill();
    }
}
