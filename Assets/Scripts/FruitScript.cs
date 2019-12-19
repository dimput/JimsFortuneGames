using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using CodeMonkey.Utils;

public class FruitScript : MonoBehaviour
{
    public static FruitScript Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.name == "player"){
            // print ("kena");
            SFXManager.Instance.PlayFruitSFX();
            Destroy(this.gameObject);
            if(GlobalScript.Instance.getHealthAwal()-GlobalScript.Instance.health<50){
                GlobalScript.Instance.health += GlobalScript.Instance.getHealthAwal()-GlobalScript.Instance.health;
            }
            else{
                GlobalScript.Instance.health += 50;
            }
        }        
    }
}
