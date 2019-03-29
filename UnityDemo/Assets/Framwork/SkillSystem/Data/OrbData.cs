
namespace GameFramework.SkillSystem
{
    public class OrbData
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
        /// 
        /// </summary>
        public OrbActionData[] createActions;
        /// <summary>
        /// 
        /// </summary>
        public OrbActionData[] triggerActions;
        /// <summary>
        /// 
        /// </summary>
        public OrbActionData[] destroyActions;
        /// <summary>
        /// 
        /// </summary>
        public OrbMotionData[] motions;
    }
}
