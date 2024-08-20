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
    //private bool Lose;
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Victory")
        {
            Destroy(gameObject);
        }
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Menu":

                key = false;
                tutorialPassed = false;

                break;

            case "World":

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

                if (win)
                {
                    //LastDialogueMark = true;
                    Transform Mark = GameObject.FindGameObjectWithTag("Orb").transform;
                    Transform Ant = GameObject.FindGameObjectWithTag("Ant").transform;


                    //orb es el tag de las activaciones de los dialogos
                    Mark.GetChild(0).gameObject.SetActive(false);
                    Mark.GetChild(2).gameObject.SetActive(true);

                    Ant.GetChild(0).gameObject.SetActive(false);


                    Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                    Mark.position = new Vector2(Spawn.position.x, Spawn.position.y);
                }

                break;

            case "CrowCrypt":

                if (win)
                {
                    Debug.Log("hola");
                    GameObject Totem = GameObject.FindGameObjectWithTag("Totem");
                    Destroy(Totem);
                }

                break;
        }

    }

    // public void MarkDialogue()
    // {

    //     // Transform Mark = GameObject.FindGameObjectWithTag("Orb").transform;
    //     // Mark.GetChild(0).gameObject.SetActive(false);
    //     // Mark.GetChild(2).gameObject.SetActive(true);

    //     // Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
    //     // Mark.position = new Vector2(Spawn.position.x, Spawn.position.y);

    //     // Transform Ant = GameObject.FindGameObjectWithTag("Ant").transform;
    //     // Ant.GetChild(0).gameObject.SetActive(false);
    // }

    // public void Key(bool Key)
    // {
    //     if (!win)
    //     {
    //         GameObject.FindGameObjectWithTag("Orb").transform.GetChild(0).gameObject.SetActive(false);
    //         GameObject.FindGameObjectWithTag("Orb").transform.GetChild(1).gameObject.SetActive(true);
    //     }

    //     if (LastDialogueMark)
    //     {
    //         GameObject.FindGameObjectWithTag("Orb").transform.GetChild(2).gameObject.SetActive(false);
    //         GameObject.FindGameObjectWithTag("Orb").transform.GetChild(3).gameObject.SetActive(true);
    //         win = false;
    //         LastDialogueMark = false;
    //     }

    //     if (Key == true)
    //     {
    //         key = Key;
    //         win = false;

    //         CustomEvent HaveKey = new CustomEvent("HaveKey")
    //             {
    //                 { "keyID", "Grave Key"}
    //             };

    //         AnalyticsService.Instance.RecordEvent(HaveKey);
    //         AnalyticsService.Instance.Flush();
    //         Debug.Log("HaveKey evento");
    //     }

    // }

    public void Key()
    {

        key = true;

        CustomEvent HaveKey = new CustomEvent("HaveKey")
            {
                { "keyID", "Grave Key"}
            };

        AnalyticsService.Instance.RecordEvent(HaveKey);
        AnalyticsService.Instance.Flush();
        Debug.Log("HaveKey evento");
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

        switch (SceneManager.GetActiveScene().name)
        {

            case "Carmin":

                enemyName = "Carmin";
                levelIndex = 1;
                DataPlayer.Instance.IsBack = true;

                break;

            case "Maxi":

                enemyName = "Pigeon";
                levelIndex = 2;
                DataPlayer.Instance.Reset();

                break;

            case "Crow":

                enemyName = "Crow";
                levelIndex = 3;
                DataPlayer.Instance.Reset();

                break;

            case "Carancho":

                enemyName = "Carancho";
                levelIndex = 4;

                break;
        }

        //Lose = true;

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


        switch (SceneManager.GetActiveScene().name)
        {

            case "Carmin":

                SceneManager.LoadScene("World");

                break;

            case "Crow":

                SceneManager.LoadScene("CrowCrypt");

                break;

            case "Carancho":

                SceneManager.LoadScene("CaranchoCrypt");

                break;
        }

    }

    public bool TutoPass()
    {
        return tutorialPassed;
    }
}
