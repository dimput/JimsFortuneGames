using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance;
    public float health=100;
    private float healthAwal;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        healthAwal = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHealthAwal(){
        return healthAwal;
    }
}
