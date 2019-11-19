using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public static MonsterScript Instance;
    
    private Animator charAnimator;
    public float healthMonster=3000;
    private float timer=3,timer2=2;

    private bool arahKanan,arahKiri;
    private float posX,posY,posZ;

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
        if(healthMonster<=0){
            Destroy(this.gameObject);
            GlobalScript.Instance.score+=100;
        }
        timer -= Time.deltaTime;
        if(timer >=0){
            posX=transform.position.x;
            posX+=speed;
            transform.position = new Vector3(posX, posY, posZ);
            charAnimator.SetBool("isWalk",true);
        }else{
            timer2 -= Time.deltaTime;
            if(timer2 >=0){
                transform.position = new Vector3(posX, posY, posZ);
                charAnimator.SetBool("isWalk",false);
            }
            else {
                timer=3;
                timer2=2;
                transform.Rotate(0,180,0);
                speed=speed*-1;
                if(arahKanan){
                    arahKiri=true;
                    arahKanan=false;
                }
                if(arahKiri){
                    arahKiri=false;
                    arahKanan=true;
                }
            }
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
