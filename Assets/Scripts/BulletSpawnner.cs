using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnner : MonoBehaviour
{
    public static BulletSpawnner Instance;
    public GameObject objectToSpawn,MonsterObject;
    public GameObject objectToSpawn2;
    // public static BulletScript Instance;
    float spawnPosX,spawnPosMonsX;
    float spawnPosY,spawnPosMonsY;

    float timer = .8f;

    public bool isFireMonster=false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(objectToSpawn, this.transform);
            // Set posisi object agar berada di sebelah kanan kamera
            spawnPosY = PlayerScript.Instance.transform.position.y + 3;
            if (PlayerScript.Instance.arahKiri)
            {
                spawnPosX = PlayerScript.Instance.transform.position.x + .4f;
            }
            if (PlayerScript.Instance.arahKanan)
            {
                spawnPosX = PlayerScript.Instance.transform.position.x + 1.6f;
            }
            obj.transform.localPosition = new Vector3(spawnPosX, spawnPosY, 70);
        }
        if(isFireMonster){
            if(timer>0){
                timer-=Time.deltaTime;
            }
            else{
                isFireMonster= false;
                GameObject obj = Instantiate(objectToSpawn2, this.transform);
                // Set posisi object agar berada di sebelah kanan kamera
                spawnPosMonsY = MonsterObject.transform.position.y-.7f;
                if (MonsterScript.Instance.arahKiri)
                {
                    spawnPosMonsX = MonsterObject.transform.position.x-2.5f;
                }
                if (MonsterScript.Instance.arahKanan)
                {
                    spawnPosMonsX = MonsterObject.transform.position.x+1.2f;
                }
                obj.transform.localPosition = new Vector3(spawnPosMonsX, spawnPosMonsY, 70);
                timer =.8f;
                isFireMonster=false;
            }
        }
    }

    public void fireMonster(){
        if(!MonsterScript.Instance.isFire){
            isFireMonster=true;
            MonsterScript.Instance.isFire=true;
        }
    }
}
