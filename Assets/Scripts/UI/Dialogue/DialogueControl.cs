using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Analytics;
using EasyTransition;
using UnityEngine.Tilemaps;

public class DialogueControl : MonoBehaviour
{

    [SerializeField] private string characName;


    [Header("Combat")]
    [SerializeField] private bool Combat;

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;

    private Animator Player;

    private void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }


    public void CombatChangeScene()
    {

        switch (characName)
        {
            case "Eddy":

                Invoke("PlayMusicBoss", 1f);

                break;

            case "Carmin":

                loadDelay = 0.8f;
                Player.Play("Zen_World");


                Invoke("PlayMusicBoss", 1f);

                CustomEvent CombatBoss = new CustomEvent("CombatBoss")
                {
                    { "nameBoss", "Carmin"},

                };

                AnalyticsService.Instance.RecordEvent(CombatBoss);
                AnalyticsService.Instance.Flush();

                 //Debug.Log("CombatBoss evento");

                break;

            case "BirdCrypt":



                CustomEvent Crypt = new CustomEvent("Crypt")
                {
                    { "cryptName", "BirdCrypt"}
                };

                AnalyticsService.Instance.RecordEvent(Crypt);
                AnalyticsService.Instance.Flush();

                CustomEvent LevelComplete = new CustomEvent("LevelComplete")
                {
                    { "levelIndex", 1f}
                };

                AnalyticsService.Instance.RecordEvent(LevelComplete);
                AnalyticsService.Instance.Flush();

                CustomEvent LevelStart = new CustomEvent("LevelStart")
                {
                    { "levelIndex", 2},
                    { "levelType", "Crypt"},

                };

                AnalyticsService.Instance.RecordEvent(LevelStart);
                AnalyticsService.Instance.Flush();


                 //Debug.Log("Crypt evento");

                break;

            case "Crow":

                loadDelay = 0.8f;

                Player.Play("Zen_World");
                Invoke("PlayMusicBoss", 1f);

                // CustomEvent CombatBoss = new CustomEvent("CombatBoss")
                // {
                //     { "nameBoss", "Karasuno"},

                // };

                // AnalyticsService.Instance.RecordEvent(CombatBoss);
                // AnalyticsService.Instance.Flush();

                 //Debug.Log("CombatBoss evento");

                break;

            case "Carancho":

                loadDelay = 0.8f;

                Player.Play("Zen_World");
                Invoke("PlayMusicBoss", 1f);

                break;


        }
        DataPlayer.Instance.SaveWorldPosition();
        //SceneManager.LoadScene(characName);
        TransitionManager.Instance().Transition(characName, transition, loadDelay);
        loadDelay = 0f;
    }

    private void PlayMusicBoss()
    {

        MusicControll.Instance.PlayBoss();
    }

    public void Key()
    {


        SceneData.Instance.key = true;

        // CustomEvent HaveKey = new CustomEvent("HaveKey")
        //     {
        //         { "keyID", "Grave Key"}
        //     };

        // AnalyticsService.Instance.RecordEvent(HaveKey);
        // AnalyticsService.Instance.Flush();
         //Debug.Log("HaveKey evento");
    }

    public void ChrisDialogue()
    {

        SceneData.Instance.chrisDialogue = true;
    }

    public void FloorWildActive()
    {

        DataPlayer.Instance.floorWild = true;
    }

    public void TilemapColliderFalse(){

        GameObject.FindGameObjectWithTag("WoodsDry").GetComponent<TilemapCollider2D>().enabled = false;
        SceneData.Instance.BackToWorld = true;
    }

    public void UILivesActive(){

        GameObject.FindGameObjectWithTag("CanvaLifes").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("CanvaLifes").transform.GetChild(1).gameObject.SetActive(true);
    }

}

