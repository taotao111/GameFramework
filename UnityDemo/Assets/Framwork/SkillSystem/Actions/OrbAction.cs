using System;

namespace GameFramework.SkillSystem
{
    public class OrbAction : IOrbAction
    {
        /// <summary>
        /// which orb owner this.
        /// </summary>
        public IOrb Holder
        {
            get;
            set;
        }
        /// <summary>
        /// trigger action
        /// </summary>
        public void Trigger()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// init
        /// </summary>
        public virtual void Init() { }
        /// <summary>
        /// data->entity
        /// </summary>
        /// <param name="p_data"></param>
        public virtual void Deserialize(OrbActionData p_data)
        {

        }

        /// <summary>
        /// entity->data,
        /// </summary>
        /// <param name="p_data"></param>
        /// <returns></returns>
        public virtual OrbActionData Serialize(OrbActionData p_data)
        {
            return null;
        }
    }
}
