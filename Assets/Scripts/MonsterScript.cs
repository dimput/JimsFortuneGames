using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public static MonsterScript Instance;
    public float healthMonster=3000;
    private float healthMonsterAwal;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        healthMonsterAwal = healthMonster;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthMonster<=0){
            Destroy(this.gameObject);
            GlobalScript.Instance.score+=100;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.tag == "Bullet"){
            // print ("kena");
            healthMonster -= 50;
        }        
    }

    public float getHealthMonsterAwal(){
        return healthMonsterAwal;
    }
}
