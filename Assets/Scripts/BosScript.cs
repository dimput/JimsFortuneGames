using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosScript : MonoBehaviour
{
    public static BosScript Instance;
    public GameObject healthBar;
    private Animator charAnimator;
    public float healthMonster=3000;
    private float timer=3,timer2=2,timer3=2;

    public bool arahKanan=false,arahKiri=true,isFire;
    private float posX,posY,posZ,spawnPosX,spawnPosY;

    public GameObject objectToSpawn;
    private float speed=-.01f;
    private float healthMonsterAwal;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        charAnimator = GetComponent<Animator>();
        healthMonsterAwal = healthMonster;
        posX= transform.position.x;
        posY= transform.position.y;
        posZ= transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = healthBar.transform;
        bar.localScale = new Vector3(healthMonster/healthMonsterAwal,1f);
        if(healthMonster<=0){
            Destroy(this.gameObject);
            GlobalScript.Instance.score+=100;
        }
    } 
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.tag == "Bullet"){
            print ("kena");
            healthMonster -= 50;
        }        
    }

    public float getHealthMonsterAwal(){
        return healthMonsterAwal;
    }
}
