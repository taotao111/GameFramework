using System.Collections;
using System.Collections.Generic;
using GameFramework.Base;
namespace GameFramework.SkillSystem
{
    public class Mo_MoveDir : OrbMotion
    {
#if EDITOR_ATTR
        [EditorAttr(viewName = "方向",index = 500)]
#endif
        public Vector3 dir = Vector3.zero;
        public override void Tick(float p_elapsedSec)
        {
            Holder.Position += dir * p_elapsedSec;
        }

        public override OrbMotionData Serialize(OrbMotionData p_data)
        {
            return base.Serialize(p_data);
        }
    }
}