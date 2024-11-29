using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCinematic : MonoBehaviour
{
    public bool stopMusic;
    public float volumeCine;

    void Start()
    {

    }


    void Update()
    {
        if (stopMusic)
        {
            MusicControll.Instance.StopMusic();
        }

        MusicControll.Instance.audioSource.volume = volumeCine;

    }
}
