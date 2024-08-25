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
    [SerializeField] private GameObject sureExitScreen;

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

        EventSystem.current.SetSelectedGameObject(ResumeGO);
    }
    private void ClosePause()
    {
        Time.timeScale = 1;
        CloseAllMenus();
    }
    private void OnSelectedResume()
    {
        pauseScreen.SetActive(false);
    }
    private void OnSelectedOptions()
    {
        //TODO Abrir Opciones
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

    #region Canvas AllMenus
    private void CloseAllMenus()
    {
        pauseScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
    #endregion
}