using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;

    public bool tutorialPassed;
    public bool key;

    private void Awake()
    {
        if (SceneData.Instance == null)
        {
            SceneData.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }  else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            key = false;
            tutorialPassed = false;
        }
        
        if(scene.name == "World" && tutorialPassed){
            Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
            Transform player = GameObject.FindGameObjectWithTag("Spawn").transform;
            player.position = new Vector2(Spawn.position.x, Spawn.position.y);
            GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Key(){
        key = true;
        GameObject.FindGameObjectWithTag("Orb").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Orb").transform.GetChild(1).gameObject.SetActive(true);
    }
    public bool HaveKey(){
        return key;
    }

    public void Loser(){
        Lose = true;
        SceneManager.LoadScene("World");
    }

    public void Winner(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool TutoPass(){
        return tutorialPassed;
    }
    public void ExitPause(){
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }
}
