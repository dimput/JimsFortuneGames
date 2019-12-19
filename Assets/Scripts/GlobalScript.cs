using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance;
    public float health=100;

    public GameObject panelGameOver,panelScore,panelPause,panelNextGames;
    public int life;
    public bool gameOver = false,gamePause=false,win=false;
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
        if(gameOver||win){
            gamePause=true;
        }
        if(win){
            SFXManager.Instance.PlayWinSFX();
            panelNextGames.SetActive(true);
        }
        if(gameOver){
            setActiveGameOver();
        }
    }

    public void nextLevel(){
        int level = PlayerPrefs.GetInt("LevelPassed");
        PlayerPrefs.SetInt ("LevelPassed",level+1);
        Application.LoadLevel ("MainMenu");
    }

    public float getHealthAwal(){
        return healthAwal;
    }
    public void setActiveGameOver(){
        panelGameOver.SetActive(true);
    }
    public void setActivePanelPause(){
        panelPause.SetActive(true);
        gamePause=true;
    }
    public void setClosePanelPause(){
        panelPause.SetActive(false);
        gamePause=false;
    }
    public void loadScene(){
        int level = PlayerPrefs.GetInt("LevelPassed");
        SceneManager.LoadScene(level);
        setClosePanelPause();
    }
}
