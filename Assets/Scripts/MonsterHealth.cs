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
        healthTemp = MonsterScript.Instance.healthMonster;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = transform.Find("Bar");
        healthBar = MonsterScript.Instance.healthMonster / healthTemp;
        bar.localScale = new Vector3(healthBar,1f);
    }
}
