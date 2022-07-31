using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public static AudioManager Instance
    {
        get => _instance;
    }

    private static AudioManager _instance;
    private bool sound = true;
    
    void Start()
    {
        _instance = this;
    }
    
    void MakeSingleton()
    {
        if(_instance != null) Destroy(gameObject);
        else
        {
            _instance = this;
            //DontDestroyOnLoad(_instance); // instance referanslı objeyi sahne yenilendiğinde yok etme
        }
    }
    
    public void PlayClipFx(AudioClip audioClip,float volume)
    {
        if(sound) AudioSource.PlayOneShot(audioClip,volume);
    }
}
