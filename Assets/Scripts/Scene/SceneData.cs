using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;

    public bool tutorialPassed;
    public bool key;
    private bool Lose;
    public bool win;
    private bool LastDialogueMark;
    private bool IsFirst = true;


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
            if (IsFirst)
            {
                CustomEvent InTown = new CustomEvent("InTown")
                {
                    { "townName", "Vulpes"}
                };

                AnalyticsService.Instance.RecordEvent(InTown);
                AnalyticsService.Instance.Flush();

                Debug.Log("InTown evento");

                IsFirst = false;
            }


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

        if (SceneManager.GetActiveScene().name == "CrowCrypt")
        {
            if (win)
            {
                Debug.Log("hola");
                GameObject Totem = GameObject.FindGameObjectWithTag("Totem");
                Destroy(Totem);
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

            CustomEvent HaveKey = new CustomEvent("HaveKey")
                {
                    { "keyID", "Grave Key"}
                };

            AnalyticsService.Instance.RecordEvent(HaveKey);
            AnalyticsService.Instance.Flush();
            Debug.Log("HaveKey evento");
        }

    }
    public bool HaveKey()
    {
        return key;
    }

    public void Pigeon()
    {
        CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
        {
            { "orbCount", 0f},
            { "enemyName", "Pigeon" },
            { "enemyCount", DataPlayer.Instance.PigeonCount}
        };

        AnalyticsService.Instance.RecordEvent(EnemyBeat);
        AnalyticsService.Instance.Flush();


        Debug.Log("EnemyBeat evento");
        //escena que vuelve al mundo desp del ataque de la paloma

        DataPlayer.Instance.IsBack = true;
        SceneManager.LoadScene("BirdCrypt");

    }

    public void Crow()
    {
        // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
        // {
        //     { "orbCount", 0f},
        //     { "enemyName", "Pigeon" },
        //     { "enemyCount", DataPlayer.Instance.PigeonCount}
        // };

        // AnalyticsService.Instance.RecordEvent(EnemyBeat);
        // AnalyticsService.Instance.Flush();


        // Debug.Log("EnemyBeat evento");
        // //escena que vuelve al mundo desp del ataque de la paloma

        DataPlayer.Instance.IsBack = true;
        SceneManager.LoadScene("CrowCrypt");

    }

    public void Carancho()
    {
        // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
        // {
        //     { "orbCount", 0f},
        //     { "enemyName", "Pigeon" },
        //     { "enemyCount", DataPlayer.Instance.PigeonCount}
        // };

        // AnalyticsService.Instance.RecordEvent(EnemyBeat);
        // AnalyticsService.Instance.Flush();


        // Debug.Log("EnemyBeat evento");
        // //escena que vuelve al mundo desp del ataque de la paloma

        DataPlayer.Instance.IsBack = true;
        SceneManager.LoadScene("CaranchoCrypt");

    }

    public void Encounters()
    {

        //escena que vuelve al mundo desp del ataque de la paloma
        //SceneManager.LoadScene("Menu");
        DataPlayer.Instance.SaveWorldPosition();
        Debug.Log("guarda");
        SceneManager.LoadScene("Maxi");

    }

    public void Loser()
    {
        string enemyName = "";
        int levelIndex = 0;

        if (SceneManager.GetActiveScene().name == "Carmin")
        {
            enemyName = "Carmin";
            levelIndex = 1;
            DataPlayer.Instance.IsBack = true;
        }

        if (SceneManager.GetActiveScene().name == "Maxi")
        {
            enemyName = "Pigeon";
            levelIndex = 2;
            DataPlayer.Instance.Reset();
        }

        if (SceneManager.GetActiveScene().name == "Crow")
        {
            enemyName = "Crow";
            levelIndex = 3;
            DataPlayer.Instance.Reset();
        }

        if (SceneManager.GetActiveScene().name == "Carancho")
        {
            enemyName = "Carancho";
            levelIndex = 4;

        }

        Lose = true;

        Debug.Log(enemyName);

        CustomEvent GameOver = new CustomEvent("GameOver")
                {
                    { "levelIndex", levelIndex},
                    { "enemyName", enemyName},
                    { "hitCount", DataPlayer.Instance.hitCount}
                };

        AnalyticsService.Instance.RecordEvent(GameOver);
        AnalyticsService.Instance.Flush();

        DataPlayer.Instance.hitCount = 0;

        SceneManager.LoadScene("GameOver");
    }


    public void Winner()
    {

        DataPlayer.Instance.IsBack = true;

        win = true;

        DataPlayer.Instance.hitCount = 0;

        if (SceneManager.GetActiveScene().name == "Carmin")
        {
            SceneManager.LoadScene("World");
        }

        if (SceneManager.GetActiveScene().name == "Crow")
        {
            SceneManager.LoadScene("CrowCrypt");
        }

        if (SceneManager.GetActiveScene().name == "Carancho")
        {
            SceneManager.LoadScene("CaranchoCrypt");
        }

    }

    public bool TutoPass()
    {
        return tutorialPassed;
    }
}
