using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControll : MonoBehaviour
{
    public static MusicControll Instance;
    public AudioSource audioSource;

    [Header("Songs")]
    [SerializeField] private AudioClip World;
    [SerializeField] private AudioClip Boss;
    [SerializeField] private AudioClip Crypt;
    [SerializeField] private AudioClip Lotor;
    private void Awake()
    {
        if (MusicControll.Instance == null)
        {
            MusicControll.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWorld()
    {
        audioSource.clip = World;
        audioSource.Play();
        audioSource.loop = true;
        //audioSource.volume = 0;

    }

    public void PlayBoss()
    {
        audioSource.clip = Boss;
        audioSource.Play();
        audioSource.loop = true;
        //audioSource.volume = 0;

    }

    public void PlayCrypt()
    {
        audioSource.clip = Crypt;
        audioSource.Play();
        audioSource.loop = true;
        //audioSource.volume = 0;

    }

    public void PlayLotor()
    {
        audioSource.clip = Lotor;
        audioSource.Play();
        audioSource.loop = true;
        //audioSource.volume = 0;

    }

    public void StopMusic()
    {
        audioSource.Stop();

    }

}
