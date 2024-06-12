using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void Play()
    {
        if (DataPlayer.Instance.pigeonLost == true)
        {
            DataPlayer.Instance.pigeonLost = false;
            SceneManager.LoadScene("BirdCrypt");

        }else
        {
            SceneManager.LoadScene("World");
        }

        
    }

    public void StartGame(){

        SceneManager.LoadScene("World");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
