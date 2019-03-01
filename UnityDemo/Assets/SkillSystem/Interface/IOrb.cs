

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// orb
    /// </summary>
    public interface IOrb : ITarget
    {
        /// <summary>
        /// 法球触发
        /// </summary>
        void Trigger(E_OrbEventType p_EventType, params object[] p_Param);
    }
}
