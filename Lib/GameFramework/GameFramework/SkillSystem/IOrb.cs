using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.SkillSystem
{
    /// <summary>
    /// 法球
    /// 法球可作为目标，所以继承ITarget
    /// </summary>
    public interface IOrb : ITarget
    {
        /// <summary>
        /// 法球触发
        /// </summary>
        void Trigger();
    }
}
