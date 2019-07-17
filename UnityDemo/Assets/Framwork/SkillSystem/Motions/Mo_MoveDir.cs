using System.Collections;
using System.Collections.Generic;
#if UNITY_PLATFORM
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
        public float speed = 0;
        public override void Tick(float p_ElapsedSec)
        {
            Holder.Position += dir * p_ElapsedSec;
        }

        public override OrbMotionData Serialize(OrbMotionData p_Data)
        {
            Mo_MoveDirData mo_data = new Mo_MoveDirData();
            base.Serialize(mo_data);
            return mo_data;
        }
        public override void Deserialize(OrbMotionData p_Data)
        {
            Mo_MoveDirData mo_data = (Mo_MoveDirData)p_Data;
            base.Deserialize(p_Data);
            speed = mo_data.speed;
            dir = mo_data.dir;
        }
    }
    public class Mo_MoveDirData : OrbMotionData
    {
        public float speed;
        public Vector3 dir;
    }
}