

namespace GameFramework.SkillSystem
{
    public abstract class OrbTrigger : IOrbTrigger
    {
        public IOrb Orb { get; set; }
        public abstract void Tick(float p_ElapsedSec);
        /// <summary>
        /// Trigger Orb Actions
        /// </summary>
        public virtual void Trigger()
        {
            Orb.Trigger(E_OrbEventType.Orb_Trigger);
        }
        /// <summary>
        /// data->entity
        /// </summary>
        /// <param name="p_data"></param>
        public virtual void Deserialize(OrbTriggerData p_data)
        {
        }

        /// <summary>
        /// entity->data,
        /// </summary>
        /// <param name="p_data"></param>
        /// <returns></returns>
        public virtual OrbTriggerData Serialize(OrbTriggerData p_data)
        {
            return null;
        }
    }
}
