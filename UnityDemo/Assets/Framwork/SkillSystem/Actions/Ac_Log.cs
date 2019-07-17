using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.SkillSystem;
public class Ac_Log : OrbAction
{
    public string content;
    public override void Trigger()
    {
        Debug.Log(content);
    }
    public override OrbActionData Serialize(OrbActionData p_Data)
    {
        Ac_LogData ac_data = new Ac_LogData();
        base.Serialize(ac_data);
        ac_data.content = content;
        return ac_data;
    }
    public override void Deserialize(OrbActionData p_Data)
    {
        base.Deserialize(p_Data);
        Ac_LogData ac_data = (Ac_LogData)p_Data;
        content = ac_data.content;
    }
}
public class Ac_LogData : OrbActionData
{
    public string content;
}
