using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest  {


    public int baseSuccesRate=0;
    public int reward;

    public Quest(int baseSr,int rew)
    {
        baseSuccesRate = baseSr;
        reward = rew;
    }
	
}
