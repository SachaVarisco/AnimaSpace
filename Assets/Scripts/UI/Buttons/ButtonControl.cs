using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class ButtonControl : MonoBehaviour
{
    public void Play()
    {
        if (DataPlayer.Instance.pigeonLost == true)
        {
            DataPlayer.Instance.pigeonLost = false;
            SceneManager.LoadScene("BirdCrypt");

        }
        else
        {
            SceneManager.LoadScene("World");
        }

        if (DataPlayer.Instance.crowLost == true)
        {
            DataPlayer.Instance.crowLost = false;
            SceneManager.LoadScene("CrowCrypt");
        }

        if (DataPlayer.Instance.caranchoLost == true)
        {
            DataPlayer.Instance.caranchoLost = false;
            SceneManager.LoadScene("CaranchoCrypt");
        }


    }

    public void StartGame()
    {

        CustomEvent LevelStart = new CustomEvent("LevelStart")
                {
                    { "levelIndex", 1},
                    { "levelType", "World"},

                };

        AnalyticsService.Instance.RecordEvent(LevelStart);
        AnalyticsService.Instance.Flush();

        SceneManager.LoadScene("World");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void ContinueLotor(){

        SceneManager.LoadScene("Lotor");
    }
}
