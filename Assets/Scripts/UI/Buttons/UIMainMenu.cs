using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using EasyTransition;

public class UIMainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject playGO;
    private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsBackGO;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private GameObject creditsBackGO;
    [SerializeField] private Button creditsBackButton;


    [Header("Panels")]
    [SerializeField] private GameObject settingsGO;
    [SerializeField] private GameObject creditsGO;
    

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(playGO);
    }
    void Awake()
    {
        //Menu buttons
        playButton = playGO.GetComponent<Button>();
        settingsButton.onClick.AddListener(OnSelectedOptions);
        playButton.onClick.AddListener(OnSelectedPlay);
        creditsButton.onClick.AddListener(OnSelectedCredits);

        // BackButtons
        settingsBackButton.onClick.AddListener(OnBackToMenu);
        creditsBackButton.onClick.AddListener(OnBackToMenu);
    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        settingsBackButton.onClick.RemoveAllListeners();
        creditsBackButton.onClick.RemoveAllListeners();
    }

    #region Canvas buttons functions
    private void OnSelectedPlay()
    {

        TransitionManager.Instance().Transition("House", transition, loadDelay);

    }
    private void OnSelectedCredits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsBackGO);
        creditsGO.SetActive(true);
    }

    private void OnSelectedOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsBackGO);
        settingsGO.SetActive(true);
    }
    private void OnBackToMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playGO);
        settingsGO.SetActive(false);
        creditsGO.SetActive(false);
    }
    #endregion
}
