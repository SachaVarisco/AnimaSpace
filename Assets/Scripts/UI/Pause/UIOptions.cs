using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIOptions : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject resumePauseButton;
    [Header("Buttons")]
    [SerializeField] private Button resetButton;

    [SerializeField] private Button backButton;

    [Header("Sliders")]
    [SerializeField] private GameObject musicGO;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(musicGO);

        musicSlider.value = MusicControll.Instance.audioSource.volume;
        soundSlider.value = AudioControll.Instance.audioSource.volume;
    }
    private void Awake() {
        backButton.onClick.AddListener(OnSelectedBack);
        resetButton.onClick.AddListener(OnSelectedReset);
        soundSlider.onValueChanged.AddListener(OnSlidedSound);
        musicSlider.onValueChanged.AddListener(OnSlidedMusic);
    }

    private void OnSelectedBack(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumePauseButton);
        pauseScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnSelectedReset(){

    }
    private void OnSlidedMusic(float volume){

        MusicControll.Instance.audioSource.volume = volume;

    }
    private void OnSlidedSound(float volume){

        AudioControll.Instance.audioSource.volume = volume;

    }
}
