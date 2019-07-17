using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.SkillSystem;
public class Test : MonoBehaviour {
    Orb orb;
	// Use this for initialization
	void Start () {
        //Factory<OrbAction> factory = new Factory<OrbAction>();
        //factory.Rigister(1, typeof(OrbAction));

        //OrbAction ac = factory.Create(1);
        //Debug.LogError("1111");
        SkillFactory.RigisterSkill();
        OrbData orbData = new OrbData() { name = "Test Orb" };
        
        //
        List<OrbActionData> createAc = new List<OrbActionData>();
        createAc.Add(new Ac_LogData() { id = 1, type = 1, name = "", content = "Orb create" });
        orbData.createActions = createAc.ToArray();
        //
        List<OrbMotionData> motions = new List<OrbMotionData>();
        motions.Add(new Mo_MoveDirData() { type = 1, name = "", speed = 10, dir = Vector3.forward });
        orbData.motions = motions.ToArray();
        //
        orb = Orb.Instantiate(null,null,null, orbData);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (orb != null)
        {
            orb.Tick(Time.deltaTime);
        }
	}
}
