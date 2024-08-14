using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    [Header ("PauseButtons")]
    [SerializeField] private GameObject optionsGO;
    [SerializeField] private Button exitButton;
    private Button optionsBt;

    [Header ("SureButtons")]
    [SerializeField] private Button yesButton;
    [SerializeField] private GameObject noGO;
    private Button noBt;

    [Header ("PopUps")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject sureExitScreen;

    private void Awake() {
        optionsBt = optionsGO.GetComponent<Button>();
        optionsBt.onClick.AddListener(OnSelectedOptions);
        exitButton.onClick.AddListener(OnSelectedExit);

        noBt = noGO.GetComponent<Button>();
        noBt.onClick.AddListener(OnSelectedSureNo);
        yesButton.onClick.AddListener(OnSelectedSureYes);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (pauseScreen.activeSelf)
            {
                ClosePause();
            }else{
                OpenPause();
            }
        }
    }
    private void OnDestroy() {
        exitButton.onClick.RemoveAllListeners();
        optionsBt.onClick.RemoveAllListeners();
    }

#region Canvas Pause PopUp
    private void OpenPause(){
        Time.timeScale = 0;
        pauseScreen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(optionsGO);
    }
    private void ClosePause(){
        Time.timeScale = 1;
        CloseAllMenus();
    }
    private void OnSelectedOptions(){
        Debug.Log("Options");
    }
    private void OnSelectedExit(){
        OpenSureExit();
        Debug.Log("Exit");
    }
#endregion

#region Canvas SureExit PoUp
    private void OpenSureExit(){
        pauseScreen.SetActive(false);
        sureExitScreen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(noGO);
    }
    private void CloseSureExit(){
        sureExitScreen.SetActive(false);
        OpenPause();
    }

    private void OnSelectedSureYes(){
        Debug.Log("Sure Exit");
    }

    private void OnSelectedSureNo(){
        CloseSureExit();
    }
#endregion

#region Canvas AllMenus
    private void CloseAllMenus(){
        pauseScreen.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }
#endregion
}