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
    [SerializeField] private Button creditsButton;

    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;

    private void OnEnable()
    {

    }
    void Awake()
    {
        playButton = playGO.GetComponent<Button>();
        playButton.onClick.AddListener(OnSelectedPlay);
    }

    // Update is called once per frame
    void Update()
    {
        playButton.onClick.RemoveAllListeners();
    }
    private void OnDestroy()
    {

    }

    #region Canvas buttons functions
    private void OnSelectedPlay()
    {
        TransitionManager.Instance().Transition("World", transition, loadDelay);

    }
    #endregion
}
