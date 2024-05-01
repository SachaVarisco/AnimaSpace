using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("World");
    }
    public void Restart(){
        SceneManager.LoadScene("Menu");
    }

    public void PauseExit(){
        SceneData.Instance.ExitPause();
    }
}
