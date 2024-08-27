using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
using EasyTransition;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;

    public bool tutorialPassed;
    public bool key;
    //private bool Lose;
    public bool win;
    public bool chrisDialogue;
    //private bool LastDialogueMark;
    private bool IsFirst = true;

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;


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

                MusicControll.Instance.PlayWorld();

                key = false;
                tutorialPassed = false;

                break;

            case "World":

                //MusicControll.Instance.StopMusic();
                MusicControll.Instance.PlayWorld();

                if (IsFirst)
                {
                    //     CustomEvent InTown = new CustomEvent("InTown")
                    // {
                    //     { "townName", "Vulpes"}
                    // };

                    //     AnalyticsService.Instance.RecordEvent(InTown);
                    //     AnalyticsService.Instance.Flush();

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
                    win = false;
                }

                break;

            case "BirdCrypt":

                MusicControll.Instance.PlayCrypt();

                if (chrisDialogue)
                {
                    Transform Chris = GameObject.FindGameObjectWithTag("Orb").transform;
                    Chris.GetChild(0).gameObject.SetActive(false);
                    Chris.GetChild(1).gameObject.SetActive(true);
                }

                break;

            case "CrowCrypt":

                MusicControll.Instance.PlayCrypt();

                if (win)
                {
                    GameObject Totem = GameObject.FindGameObjectWithTag("Totem");
                    Destroy(Totem);
                    win = false;
                }

                break;

        }

    }

    // public void EndTutorial()
    // {

    //     tutorialPassed = true;

    //     //evento tutorial
    //     // AnalyticsService.Instance.RecordEvent("TutoComplete");
    //     // AnalyticsService.Instance.Flush();

    //     Debug.Log("TutoComplete evento");


    //     SceneManager.LoadScene("World");
    // }

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

    // public void Key()
    // {

    //     key = true;

    //     // CustomEvent HaveKey = new CustomEvent("HaveKey")
    //     //     {
    //     //         { "keyID", "Grave Key"}
    //     //     };

    //     // AnalyticsService.Instance.RecordEvent(HaveKey);
    //     // AnalyticsService.Instance.Flush();
    //     Debug.Log("HaveKey evento");
    // }

    public bool HaveKey()
    {
        return key;
    }

    public void Pigeon()
    {
        // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
        // {
        //     { "orbCount", 0f},
        //     { "enemyName", "Pigeon" },
        //     { "enemyCount", DataPlayer.Instance.PigeonCount}
        // };

        // AnalyticsService.Instance.RecordEvent(EnemyBeat);
        // AnalyticsService.Instance.Flush();


        Debug.Log("EnemyBeat evento");
        //escena que vuelve al mundo desp del ataque de la paloma

        DataPlayer.Instance.IsBack = true;
        //SceneManager.LoadScene("BirdCrypt");
        TransitionManager.Instance().Transition("BirdCrypt", transition, loadDelay);

    }

    // public void Crow()
    // {
    //     chrisDialogue = false;
    //     // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
    //     // {
    //     //     { "orbCount", 0f},
    //     //     { "enemyName", "Pigeon" },
    //     //     { "enemyCount", DataPlayer.Instance.PigeonCount}
    //     // };

    //     // AnalyticsService.Instance.RecordEvent(EnemyBeat);
    //     // AnalyticsService.Instance.Flush();


    //     // Debug.Log("EnemyBeat evento");
    //     // //escena que vuelve al mundo desp del ataque de la paloma

    //     DataPlayer.Instance.IsBack = true;
    //     //SceneManager.LoadScene("CrowCrypt");
    //     TransitionManager.Instance().Transition("CrowCrypt", transition, loadDelay);

    // }

    // public void Carancho()
    // {
    //     // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
    //     // {
    //     //     { "orbCount", 0f},
    //     //     { "enemyName", "Pigeon" },
    //     //     { "enemyCount", DataPlayer.Instance.PigeonCount}
    //     // };

    //     // AnalyticsService.Instance.RecordEvent(EnemyBeat);
    //     // AnalyticsService.Instance.Flush();


    //     // Debug.Log("EnemyBeat evento");
    //     // //escena que vuelve al mundo desp del ataque de la paloma

    //     DataPlayer.Instance.IsBack = true;
    //     //SceneManager.LoadScene("CaranchoCrypt");
    //     TransitionManager.Instance().Transition("CaranchoCrypt", transition, loadDelay);

    // }

    // public void Puzzle2()
    // {
    //     // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
    //     // {
    //     //     { "orbCount", 0f},
    //     //     { "enemyName", "Pigeon" },
    //     //     { "enemyCount", DataPlayer.Instance.PigeonCount}
    //     // };

    //     // AnalyticsService.Instance.RecordEvent(EnemyBeat);
    //     // AnalyticsService.Instance.Flush();


    //     // Debug.Log("EnemyBeat evento");
    //     // //escena que vuelve al mundo desp del ataque de la paloma

    //     //DataPlayer.Instance.IsBack = true;
    //     //SceneManager.LoadScene("Puzzle2");
    //     TransitionManager.Instance().Transition("Puzzle2", transition, loadDelay);

    // }

    // public void Puzzle3()
    // {
    //     // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
    //     // {
    //     //     { "orbCount", 0f},
    //     //     { "enemyName", "Pigeon" },
    //     //     { "enemyCount", DataPlayer.Instance.PigeonCount}
    //     // };

    //     // AnalyticsService.Instance.RecordEvent(EnemyBeat);
    //     // AnalyticsService.Instance.Flush();


    //     // Debug.Log("EnemyBeat evento");
    //     // //escena que vuelve al mundo desp del ataque de la paloma

    //     //DataPlayer.Instance.IsBack = true;
    //     //SceneManager.LoadScene("Puzzle3");
    //     TransitionManager.Instance().Transition("Puzzle3", transition, loadDelay);

    // }

    public void Encounters()
    {

        //escena que vuelve al mundo desp del ataque de la paloma
        //SceneManager.LoadScene("Menu");
        DataPlayer.Instance.SaveWorldPosition();
        Debug.Log("guarda");
        //SceneManager.LoadScene("Maxi");
        TransitionManager.Instance().Transition("Maxi", transition, loadDelay);

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
                chrisDialogue = false;
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

        // CustomEvent GameOver = new CustomEvent("GameOver")
        //         {
        //             { "levelIndex", levelIndex},
        //             { "enemyName", enemyName},
        //             { "hitCount", DataPlayer.Instance.hitCount}
        //         };

        // AnalyticsService.Instance.RecordEvent(GameOver);
        // AnalyticsService.Instance.Flush();

        DataPlayer.Instance.hitCount = 0;

        //SceneManager.LoadScene("GameOver");
        MusicControll.Instance.StopMusic();
        TransitionManager.Instance().Transition("GameOver", transition, loadDelay);
    }


    public void Winner()
    {

        DataPlayer.Instance.IsBack = true;

        win = true;

        DataPlayer.Instance.hitCount = 0;


        switch (SceneManager.GetActiveScene().name)
        {

            case "Carmin":

                //SceneManager.LoadScene("World");
                TransitionManager.Instance().Transition("World", transition, loadDelay);

                break;

            case "Crow":

                //SceneManager.LoadScene("CrowCrypt");
                TransitionManager.Instance().Transition("CrowCrypt", transition, loadDelay);

                break;

            case "Carancho":

                //SceneManager.LoadScene("CaranchoCrypt");
                TransitionManager.Instance().Transition("CaranchoCrypt", transition, loadDelay);

                break;
        }

    }

    public bool TutoPass()
    {
        return tutorialPassed;
    }
}
