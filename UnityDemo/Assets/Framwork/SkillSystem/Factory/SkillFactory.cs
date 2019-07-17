using System;
using System.Collections.Generic;
using GameFramework.FactorySystem;
using GameFramework.SkillSystem;

public class SkillFactory {
    private static Factory<OrbAction> acFactory = new Factory<OrbAction>();
    private static Factory<OrbTrigger> tgFactory = new Factory<OrbTrigger>();
    private static Factory<OrbMotion> moFactory = new Factory<OrbMotion>();
    private static Factory<TargetSearch> tsFactory = new Factory<TargetSearch>();

    public static void RigisterSkill()
    {
        RigisterAction(1, typeof(Ac_Log));
        RigisterMotion(1, typeof(Mo_MoveDir));
    }
    /// <summary>
    /// rigister action factory
    /// </summary>
    /// <param name="p_Key"></param>
    /// <param name="p_Type"></param>
    public static void RigisterAction(int p_Key, Type p_Type)
    {
        acFactory.Rigister(p_Key, p_Type);
    }
    /// <summary>
    /// create action
    /// </summary>
    /// <param name="p_Data"></param>
    /// <returns></returns>
    public static OrbAction CreateAction(OrbActionData p_Data)
    {
        OrbAction ac = acFactory.Create(p_Data.type);
        ac.Deserialize(p_Data);
        return ac;
    }
    /// <summary>
    /// rigister motion factory
    /// </summary>
    /// <param name="p_Key"></param>
    /// <param name="p_Type"></param>
    public static void RigisterMotion(int p_Key, Type p_Type)
    {
        moFactory.Rigister(p_Key, p_Type);
    }
    /// <summary>
    /// create motion
    /// </summary>
    /// <param name="p_Data"></param>
    /// <returns></returns>
    public static OrbMotion CreateMotion(OrbMotionData p_Data)
    {
        OrbMotion mo = moFactory.Create(p_Data.type);
        mo.Deserialize(p_Data);
        return mo;
    }
    /// <summary>
    /// rigister trigger factory
    /// </summary>
    /// <param name="p_Key"></param>
    /// <param name="p_Type"></param>
    public static void RigisterTrigger(int p_Key, Type p_Type)
    {
        tgFactory.Rigister(p_Key, p_Type);
    }
    /// <summary>
    /// create trigger
    /// </summary>
    /// <param name="p_Data"></param>
    /// <returns></returns>
    public static OrbTrigger CreateTrigger(OrbTriggerData p_Data)
    {
        OrbTrigger tg = tgFactory.Create(p_Data.type);
        tg.Deserialize(p_Data);
        return tg;
    }
    /// <summary>
    /// rigister Target Search factory
    /// </summary>
    /// <param name="p_Key"></param>
    /// <param name="p_Type"></param>
    public static void RigisterTS(int p_Key, Type p_Type)
    {
        tsFactory.Rigister(p_Key, p_Type);
    }
    /// <summary>
    /// create Target Search
    /// </summary>
    /// <param name="p_Data"></param>
    /// <returns></returns>
    public static TargetSearch CreateTS(TargetData p_Data)
    {
        TargetSearch ts = tsFactory.Create(p_Data.type);
        ts.Deserialize(p_Data);
        return ts;
    }
}
