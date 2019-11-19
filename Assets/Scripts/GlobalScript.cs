using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance;
    public float health=100;

    public GameObject panelGameOver,panelScore;
    public int life;
    public bool gameOver = false,gamePause=false;
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
        if(gameOver){
            gamePause=true;
        }
    }

    public float getHealthAwal(){
        return healthAwal;
    }
    public void setActiveGameOver(){
        panelGameOver.SetActive(true);
    }
}
