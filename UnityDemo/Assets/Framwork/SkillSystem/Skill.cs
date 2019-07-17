using System.Collections;
using System.Collections.Generic;
namespace GameFramework.SkillSystem
{
    public class Skill
    {
        public List<Orb> orbs = new List<Orb>();

        public static Skill Create(int id)
        {
            Skill skill = new Skill();
            return skill;
        }
    }
}