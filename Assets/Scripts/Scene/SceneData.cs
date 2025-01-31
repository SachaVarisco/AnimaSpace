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

    public bool BackToWorld; //Bob el constructor
    public bool BushesDelete;

    [Header("Transitions")]
    [SerializeField] public TransitionSettings transition;
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

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                MusicControll.Instance.PlayWorld();

                key = false;
                tutorialPassed = false;
                win = false;
                chrisDialogue = false;
                BackToWorld = false;
                BushesDelete = false;
                DataPlayer.Instance.Reset();
                DataPlayer.Instance.pigeonLost = false;
                DataPlayer.Instance.crowLost = false;
                DataPlayer.Instance.caranchoLost = false;
                GameObject.FindGameObjectWithTag("CanvaLifes").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("CanvaLifes").transform.GetChild(1).gameObject.SetActive(false);


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

                    //Debug.Log("InTown evento");

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
                    Invoke("AnimationZenMode", 0.1f);
                    //LastDialogueMark = true;
                    Transform Mark = GameObject.FindGameObjectWithTag("Mark").transform;
                    Transform Ant = GameObject.FindGameObjectWithTag("Ant").transform;


                    //orb es el tag de las activaciones de los dialogos
                    Mark.GetChild(0).gameObject.SetActive(false);
                    Mark.GetChild(5).gameObject.SetActive(false); //arbustos
                    Mark.GetChild(2).gameObject.SetActive(true);

                    Ant.GetChild(0).gameObject.SetActive(false);


                    Transform Spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
                    Mark.position = new Vector2(Spawn.position.x, Spawn.position.y);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().animator.Play("Zen_World");
                    win = false;
                }

                if (BackToWorld)
                {
                    Transform Bob = GameObject.FindGameObjectWithTag("Bob").transform;
                    Bob.GetComponent<DialogueControl>().TilemapColliderFalse();

                    Bob.GetChild(0).gameObject.SetActive(false);
                    Bob.GetChild(1).gameObject.SetActive(true);

                }

                if (BushesDelete)
                {
                    Transform Mark = GameObject.FindGameObjectWithTag("Mark").transform;
                    // Mark.GetChild(0).gameObject.SetActive(false);
                    // Mark.GetChild(1).gameObject.SetActive(true);
                    Mark.GetChild(5).gameObject.SetActive(false); //arbustos
                }


                break;

            case "BirdCrypt":

                GameObject.FindGameObjectWithTag("CanvaLifes").SetActive(true);
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
                    Invoke("AnimationZenMode", 0.1f);
                    GameObject Totem = GameObject.FindGameObjectWithTag("Totem");
                    Destroy(Totem);
                    win = false;
                }

                break;

            case "CaranchoCrypt":

                MusicControll.Instance.PlayCrypt();

                if (win)
                {
                    Invoke("AnimationZenMode", 0.1f);
                    GameObject Totem = GameObject.FindGameObjectWithTag("Totem");
                    Destroy(Totem);
                    win = false;
                }

                break;

            case "Puzzle1_Solved":

                MusicControll.Instance.PlayCrypt();

                break;

            case "Lotor":

                MusicControll.Instance.PlayLotor();


                break;

            case "House":
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                MusicControll.Instance.PlayCinematicHouse();


                break;
        }

    }

    private void AnimationZenMode()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().StopMovement();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWorldControl>().animator.Play("Zen_World");
    }



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


        //Debug.Log("EnemyBeat evento");
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
        //Debug.Log("guarda");
        //SceneManager.LoadScene("Maxi");
        TransitionManager.Instance().Transition("Maxi", transition, loadDelay);
        MusicControll.Instance.PlayBoss();

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
                BushesDelete = true;

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

        //Debug.Log(enemyName);

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
        //TransitionSettings newTransition = transition;

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
