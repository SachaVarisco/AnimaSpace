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

    private bool Lose;
    private bool Win;
    private GameObject Pause;

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
    }
    public void OnSceneLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            key = false;
            tutorialPassed = false;
        }
        
        if(SceneManager.GetActiveScene().name == "World"){
            if (tutorialPassed == true)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().CanMove = true;
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(1).gameObject.SetActive(true);
            }
            if (Lose)
            {
                Lose = false;
                Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                player.position = new Vector2(Spawn.position.x, Spawn.position.y);

                Destroy(GameObject.FindGameObjectWithTag("RockWall"));
            }    
        }

    }
    /*private void Update() {
        if (Input.GetButtonDown("Pause") && Pause != null)
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
    }*/

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
