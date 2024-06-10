using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControll : MonoBehaviour
{
    public static MusicControll Instance;
    private AudioSource audioSource;

    [Header ("Songs")]
    [SerializeField] private AudioClip World;
    [SerializeField] private AudioClip Boss;
    private void Awake()
    {
       if (MusicControll.Instance == null)
        {
            MusicControll.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }  else
        {
            Destroy(gameObject);
        } 
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWorld(){
        audioSource.loop = true;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void PlayBoss(){
        audioSource.loop = true;
        //audioSource.volume = 0;
        audioSource.Play();
    }
}
