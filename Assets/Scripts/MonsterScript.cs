using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public static MonsterScript Instance;
    public ParticleSystem dot;
    public GameObject healthBar,firecollider;
    private Animator charAnimator;
    public float healthMonster = 3000;
    private float timer = 3, timer2 = 4, timer3 = 2,timerFire=1;

    public bool arahKanan = false, arahKiri = true, isFire;
    private float posX, posY, posZ, spawnPosX, spawnPosY;

    public GameObject objectToSpawn;
    private float speed = -.01f;
    private float healthMonsterAwal;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        charAnimator = GetComponent<Animator>();
        // dot = GetComponent<ParticleSystem>();
        healthMonsterAwal = healthMonster;
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = healthBar.transform;
        bar.localScale = new Vector3(healthMonster / healthMonsterAwal, 1f);
        if (healthMonster <= 0)
        {
            Destroy(this.gameObject);
            GlobalScript.Instance.score += 100;
        }
        if (!GlobalScript.Instance.gamePause)
        {
            timer -= Time.deltaTime;
            if (timer >= 0)
            {
                posX = transform.position.x;
                posX += speed;
                transform.position = new Vector3(posX, posY, posZ);
                charAnimator.SetBool("isWalk", true);
            }
            else
            {
                timer2 -= Time.deltaTime;
                if (timer2 >= 0)
                {
                    transform.position = new Vector3(posX, posY, posZ);
                    charAnimator.SetBool("isFire", true);
                    charAnimator.SetBool("isWalk", false);
                    timerFire-=Time.deltaTime;
                    if(timerFire <= 0){
                        dot.Play();
                        firecollider.SetActive(true);
                    }
                }
                else
                {
                    timer3 -= Time.deltaTime;
                    if (timer3 >= 0)
                    {
                        transform.position = new Vector3(posX, posY, posZ);
                        charAnimator.SetBool("isFire", false);
                        dot.Stop();
                        firecollider.SetActive(false);
                        isFire = false;
                    }
                    else
                    {
                        timerFire=1f;
                        timer = 3;
                        timer2 = 4;
                        timer3 = 2;
                        transform.Rotate(0, 180, 0);
                        speed = speed * -1;
                        if (arahKanan)
                        {
                            arahKiri = true;
                            arahKanan = false;
                        }
                        else
                        {
                            arahKiri = false;
                            arahKanan = true;
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            // print ("kena");
            healthMonster -= 50;
        }
    }

    public float getHealthMonsterAwal()
    {
        return healthMonsterAwal;
    }
}
