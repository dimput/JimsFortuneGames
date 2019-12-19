using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    AudioSource audioSource;
    public GameObject btnMusicON;
    public Slider volumeSlider; 
    [Header("Player Prefs")]
    string PREF_BGMVOL="bgmvol";
    string PREF_BGMSTATUS="bgmstatus";
    private static bool bgm = true;
    // Start is called before the first frame update
    void Start()
    {        
       Instance= this; 
       audioSource= GetComponent<AudioSource>();
       audioSource.volume=volumeSlider.value=PlayerPrefs.GetFloat(PREF_BGMVOL, 0.5f);
    //    if(PlayerPrefs.GetInt(PREF_BGMSTATUS,1)==1){
    //         audioSource.Play();
    //         btnMusicON.SetActive(true);
    //     }else{
    //         audioSource.Pause();
    //         btnMusicON.SetActive(false);
    //     }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Btnbgm(){
        if(bgm==true){
            audioSource.Pause();
            btnMusicON.SetActive(false);
            bgm =false;
        }else{
            audioSource.Play();
            btnMusicON.SetActive(true);
            bgm=true;
        }
    }
    public void SetVolume(){
        audioSource.volume= volumeSlider.value;
        PlayerPrefs.SetFloat(PREF_BGMVOL, audioSource.volume);
    }
    // public void ToogleMusic(){
    //     if(audioSource.isPlaying){
    //         audioSource.Pause();
    //         btnMusicON.SetActive(true);
    //     }else{
    //         audioSource.Play();
    //         btnMusicON.SetActive(false);

    //     }
    // }
}
