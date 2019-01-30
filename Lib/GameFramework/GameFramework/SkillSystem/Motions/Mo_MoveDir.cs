using System.Collections;
using System.Collections.Generic;
#if UNITY_DLL
using Vector3 = UnityEngine.Vector3;
#else
using Vector3 = GameFramework.Base.Vector3;
#endif
namespace GameFramework.SkillSystem
{
    public class Mo_MoveDir : Mo_Move
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