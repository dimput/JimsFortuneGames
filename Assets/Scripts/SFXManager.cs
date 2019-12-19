using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    AudioSource audioSource;
    public Slider volumeSlider;
    public GameObject btnSfxON;
    [Header("Player Prefs")]
    string PREF_SFXVOL="sfxvol";
    string PREF_SFXSTATUS="sfxsatus";

    public AudioClip coinSfx;
    public AudioClip fruitSfx;
    public AudioClip shotSfx;
    public AudioClip clickSfx,winSfx;
    public AudioClip gameoverSfx;
    private bool isOn = true;


    // Start is called before the first frame update
    void Start()
    {
        Instance=this;
        audioSource=GetComponent<AudioSource>();
        audioSource.volume=volumeSlider.value=PlayerPrefs.GetFloat(PREF_SFXVOL, 0.5f);

    }
    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
    public void PlayCoinSFX(){
        if(isOn==true){
        PlaySound(coinSfx);
        }
    }
    public void PlayWinSFX(){
        if(isOn==true){
        PlaySound(winSfx);}
    }
    public void PlayFruitSFX(){
        if(isOn==true){
        PlaySound(fruitSfx);}
    }
    public void PlayShotSFX(){
        if(isOn==true){
        PlaySound(shotSfx);}
    }
    public void PlayClickSFX(){
        if(isOn==true){
        PlaySound(clickSfx);}
    }
    public void PlayGameoverSFX(){
        if(isOn==true){
        PlaySound(gameoverSfx);}
    }

    public void SetVolume(){
        audioSource.volume= volumeSlider.value;
        PlayerPrefs.SetFloat(PREF_SFXVOL, audioSource.volume);
    }
    public void Btnsfx(){
        if(isOn==true){
            audioSource.Pause();
            btnSfxON.SetActive(false);
            isOn =false;
        }else{
            audioSource.Play();
            btnSfxON.SetActive(true);
            isOn=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
