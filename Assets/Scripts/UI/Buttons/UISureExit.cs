using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using EasyTransition;

public class UISureExit : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button yesButton;

    [SerializeField] private Button noButton;
    [SerializeField] private GameObject noGO;
    [SerializeField] private GameObject ResumeGO;


    [Header("Screens")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(noGO);
    }
    private void Awake()
    {
        noButton.onClick.AddListener(OnSelectedSureNo);
        yesButton.onClick.AddListener(OnSelectedSureYes);
    }
    private void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }

    private void OnSelectedSureYes()
    {
        Time.timeScale = 1;
        TransitionManager.Instance().Transition("Menu", transition, loadDelay);
    }

    private void OnSelectedSureNo()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ResumeGO);
        pauseScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
