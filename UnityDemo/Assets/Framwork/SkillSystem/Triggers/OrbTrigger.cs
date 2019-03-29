

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
    }
}
