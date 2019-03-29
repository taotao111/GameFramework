
namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 法球的行为
    /// </summary>
    public interface IOrbAction
    {
        /// <summary>
        /// 持有者
        /// </summary>
        IOrb Holder { get; set; }
        /// <summary>
        /// 行为的触发
        /// </summary>
        void Trigger();
    }
}
