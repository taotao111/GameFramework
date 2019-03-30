using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.SkillSystem;
public class TS_ScenePos : TargetSearch
{
    public Vector3 pos = Vector3.zero;
    public override List<ITarget> Search()
    {
        EmptyTarget target = new EmptyTarget();
        target.Position = pos;
        return new List<ITarget>() { target };
    }
}
