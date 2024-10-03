using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
using EasyTransition;

public class CryptDoor : MonoBehaviour
{
    [SerializeField] private AudioClip doorSound;
    //private AudioSource audioSource;
    private string NextScene;

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;
    void OnEnable()
    {

        if (gameObject.name == "Puerta-Cripta2")
        {
            AudioControll.Instance.PlaySound(doorSound);
        }

    }
    void Update()
    {
        if (DataPlayer.Instance.Ready == true)
        {
            gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.SetActive(false);
            DataPlayer.Instance.Ready = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "House":
                    NextScene = "World";
                    break;
                case "Puzzle1_Solved":
                    NextScene = "BirdCrypt";
                    break;
                case "Puzzle2":
                    NextScene = "CrowCrypt";
                    break;
                case "Puzzle3":
                    GameObject.FindGameObjectWithTag("CanvaLifes").SetActive(false);
                    NextScene = "CaranchoCrypt";
                    break;
                case "BirdCrypt":
                    NextScene = "Puzzle2";
                    break;
                case "CrowCrypt":
                    NextScene = "Puzzle3";
                    break;
                case "CaranchoCrypt":
                    NextScene = "Victory";
                    break;

            }
            // CustomEvent LevelComplete = new CustomEvent("LevelComplete")
            //     {
            //         { "levelIndex", 2f}
            //     };

            // AnalyticsService.Instance.RecordEvent(LevelComplete);
            // AnalyticsService.Instance.Flush();

            // CustomEvent EndCrypt = new CustomEvent("EndCrypt")
            //     {
            //         { "cryptName", "BirdCrypt"}
            //     };

            // AnalyticsService.Instance.RecordEvent(EndCrypt);
            // AnalyticsService.Instance.Flush();

            //Debug.Log("EndCrypt evento");


            TransitionManager.Instance().Transition(NextScene, transition, loadDelay);
        }

        //if (other.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "Puzzle2")
        //{
        // CustomEvent LevelComplete = new CustomEvent("LevelComplete")
        //     {
        //         { "levelIndex", 2f}
        //     };

        // AnalyticsService.Instance.RecordEvent(LevelComplete);
        // AnalyticsService.Instance.Flush();

        // CustomEvent EndCrypt = new CustomEvent("EndCrypt")
        //     {
        //         { "cryptName", "BirdCrypt"}
        //     };

        // AnalyticsService.Instance.RecordEvent(EndCrypt);
        // AnalyticsService.Instance.Flush();

        //Debug.Log("EndCrypt evento");


        //    SceneManager.LoadScene("CrowCrypt");
        //}

        //if (other.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "Puzzle3")
        //{
        // CustomEvent LevelComplete = new CustomEvent("LevelComplete")
        //     {
        //         { "levelIndex", 2f}
        //     };

        // AnalyticsService.Instance.RecordEvent(LevelComplete);
        // AnalyticsService.Instance.Flush();

        // CustomEvent EndCrypt = new CustomEvent("EndCrypt")
        //     {
        //         { "cryptName", "BirdCrypt"}
        //     };

        // AnalyticsService.Instance.RecordEvent(EndCrypt);
        // AnalyticsService.Instance.Flush();

        //Debug.Log("EndCrypt evento");


        // SceneManager.LoadScene("CaranchoCrypt");
        // }

        //if (other.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "BirdCrypt")
        //{
        // CustomEvent LevelComplete = new CustomEvent("LevelComplete")
        //     {
        //         { "levelIndex", 2f}
        //     };

        // AnalyticsService.Instance.RecordEvent(LevelComplete);
        // AnalyticsService.Instance.Flush();

        // CustomEvent EndCrypt = new CustomEvent("EndCrypt")
        //     {
        //         { "cryptName", "BirdCrypt"}
        //     };

        // AnalyticsService.Instance.RecordEvent(EndCrypt);
        // AnalyticsService.Instance.Flush();

        //Debug.Log("EndCrypt evento");


        //   SceneManager.LoadScene("Puzzle2");
        //}

        //if (other.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "CrowCrypt")
        //{
        // CustomEvent LevelComplete = new CustomEvent("LevelComplete")
        //     {
        //         { "levelIndex", 3f}
        //     };

        // AnalyticsService.Instance.RecordEvent(LevelComplete);
        // AnalyticsService.Instance.Flush();

        // CustomEvent EndCrypt = new CustomEvent("EndCrypt")
        //     {
        //         { "cryptName", "CrowCrypt"}
        //     };

        // AnalyticsService.Instance.RecordEvent(EndCrypt);
        // AnalyticsService.Instance.Flush();

        //Debug.Log("EndCrypt evento");


        //    SceneManager.LoadScene("Puzzle3");
        //}
    }
}
