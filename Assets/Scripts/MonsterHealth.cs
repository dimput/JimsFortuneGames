using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    private float healthBar;
    private float healthTemp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthTemp = MonsterScript.Instance.getHealthMonsterAwal();
        Transform bar = transform.Find("Bar");
        healthBar = MonsterScript.Instance.healthMonster / healthTemp;
        // print(healthBar);
        bar.localScale = new Vector3(healthBar,1f);
    }
}
