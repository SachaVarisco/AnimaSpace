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
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            key = false;
            tutorialPassed = false;
        }
        
        if(SceneManager.GetActiveScene().name == "World"){

            Debug.Log("InTown evento");

            if (tutorialPassed)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().CanMove = true;
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(1).gameObject.SetActive(true);
            }
            if (Lose)
            {
                Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                player.position = new Vector2(Spawn.position.x, Spawn.position.y);
            }
        }
    }

    public void Key(){
        key = true;
        Debug.Log("HaveKey evento");
        GameObject.FindGameObjectWithTag("Orb").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Orb").transform.GetChild(1).gameObject.SetActive(true);
    }
    public bool HaveKey(){
        return key;
    }

    public void Pigeon(){

        Debug.Log("EnemyBeat evento");
        //escena que vuelve al mundo desp del ataque de la paloma
        SceneManager.LoadScene("Menu");
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
}
