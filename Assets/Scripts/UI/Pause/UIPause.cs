using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    [Header("PauseButtons")]
    [SerializeField] private GameObject ResumeGO;
    private Button ResumeBt;
    [SerializeField] private Button optionsBt;
    [SerializeField] private Button exitButton;

    [Header("Screens")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject optionsScreen;
    [SerializeField] private GameObject sureExitScreen;

    //[Header("MiniMap")]
    //[SerializeField] private GameObject miniMap;
    private void Awake()
    {
        ResumeBt = ResumeGO.GetComponent<Button>();
        ResumeBt.onClick.AddListener(OnSelectedResume);
        optionsBt.onClick.AddListener(OnSelectedOptions);
        exitButton.onClick.AddListener(OnSelectedExit);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (pauseScreen.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }
    private void OnDestroy()
    {
        ResumeBt.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        optionsBt.onClick.RemoveAllListeners();
    }

    #region Canvas Pause PopUp
    private void OpenPause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
        sureExitScreen.SetActive(false);

        //miniMap.SetActive(true);

        EventSystem.current.SetSelectedGameObject(ResumeGO);
    }
    private void OnSelectedResume()
    {
        ClosePause();
    }
    private void ClosePause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        //miniMap.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void OnSelectedOptions()
    {
        //TODO Abrir Opciones
        optionsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    private void OnSelectedExit()
    {
        OpenSureExit();
    }
    #endregion

    #region Canvas SureExit PoUp
    private void OpenSureExit()
    {
        pauseScreen.SetActive(false);
        sureExitScreen.SetActive(true);
    }
    #endregion
}