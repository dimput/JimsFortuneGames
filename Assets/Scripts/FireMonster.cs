using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    public static FireMonster Instance;
    public GameObject objectToSpawn2;
    float spawnPosMonsX;
    float spawnPosMonsY;
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
        if(isFireMonster){
            if(timer>0){
                timer-=Time.deltaTime;
            }
            else{
                isFireMonster= false;
                GameObject obj = Instantiate(objectToSpawn2, this.transform);
                // Set posisi object agar berada di sebelah kanan kamera
                spawnPosMonsY = MonsterScript.Instance.transform.position.y + 3.9f;
                if (MonsterScript.Instance.arahKiri)
                {
                    spawnPosMonsX = MonsterScript.Instance.transform.position.x - 7;
                }
                if (MonsterScript.Instance.arahKanan)
                {
                    spawnPosMonsX = MonsterScript.Instance.transform.position.x - 7.6f;
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
