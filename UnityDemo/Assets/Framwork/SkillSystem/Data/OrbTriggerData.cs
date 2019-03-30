
namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 触发器类型
    /// </summary>
    public enum E_TriggerType
    {
        None = 0,
    }
    public abstract class OrbTriggerData
    {
        /// <summary>
        /// Id
        /// </summary>
        public uint id;
        /// <summary>
        /// name
        /// </summary>
        public string name;
        /// <summary>
        /// comment
        /// </summary>
        public string comment;
        /// <summary>
        /// type
        /// </summary>
        public int type;
    }
}
