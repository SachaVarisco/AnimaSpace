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
    public bool win;
    private bool LastDialogueMark;


    private void Awake()
    {
        if (SceneData.Instance == null)
        {
            SceneData.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Victory")
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

        if (SceneManager.GetActiveScene().name == "World")
        {

            Debug.Log("InTown evento");

            if (tutorialPassed)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().CanMove = true;
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Eddy").transform.GetChild(1).gameObject.SetActive(true);
            }
            if (Lose)
            {
                // Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                // Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                // player.position = new Vector2(Spawn.position.x, Spawn.position.y);
            }

            if (win)
            {
                LastDialogueMark = true;
                Transform Mark = GameObject.FindGameObjectWithTag("Orb").transform;
                GameObject Ant = GameObject.FindGameObjectWithTag("Ant");

                //orb es el tag de las activaciones de los dialogos
                Mark.GetChild(0).gameObject.SetActive(false);
                Mark.GetChild(2).gameObject.SetActive(true);

                Ant.GetComponent<DialogueControl>().enabled = false;

                Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                Mark.position = new Vector2(Spawn.position.x, Spawn.position.y);
            }
        }
    }

    public void Key(bool Key)
    {
        if (!win)
        {
            GameObject.FindGameObjectWithTag("Orb").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Orb").transform.GetChild(1).gameObject.SetActive(true);
        }

        if (LastDialogueMark)
        {
            GameObject.FindGameObjectWithTag("Orb").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Orb").transform.GetChild(3).gameObject.SetActive(true);
            win = false;
            LastDialogueMark = false;
        }

        if (Key == true)
        {
            key = Key;
            win = false;
            Debug.Log("HaveKey evento");
        }

    }
    public bool HaveKey()
    {
        return key;
    }

    public void Pigeon()
    {

        Debug.Log("EnemyBeat evento");
        //escena que vuelve al mundo desp del ataque de la paloma

        DataPlayer.Instance.IsBack = true;
        SceneManager.LoadScene("BirdCrypt");

    }

    public void Encounters()
    {

        //Debug.Log("EnemyBeat evento");
        //escena que vuelve al mundo desp del ataque de la paloma
        //SceneManager.LoadScene("Menu");
        DataPlayer.Instance.SaveWorldPosition();
        Debug.Log("guarda");
        SceneManager.LoadScene("Maxi");

    }

    public void Loser()
    {
        if (SceneManager.GetActiveScene().name == "Carmin")
        {
            DataPlayer.Instance.IsBack = true;
        }

        if (SceneManager.GetActiveScene().name == "Maxi")
        {
            DataPlayer.Instance.Reset();
        }

        Lose = true;
        SceneManager.LoadScene("GameOver");
    }


    public void Winner()
    {

        DataPlayer.Instance.IsBack = true;

        win = true;
        SceneManager.LoadScene("World");
    }

    public bool TutoPass()
    {
        return tutorialPassed;
    }
}
