using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EasyTransition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRestartButton : MonoBehaviour
{
    private Button button;
    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;
    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if (DataPlayer.Instance.pigeonLost == true)
        {
            DataPlayer.Instance.pigeonLost = false;
            SceneManager.LoadScene("BirdCrypt");
            //TransitionManager.Instance().Transition("BirdCrypt", transition, loadDelay);

        }
        else
        {
            SceneManager.LoadScene("World");
            //TransitionManager.Instance().Transition("World", transition, loadDelay);
        }

        if (DataPlayer.Instance.crowLost == true)
        {
            DataPlayer.Instance.crowLost = false;
            SceneManager.LoadScene("CrowCrypt");
            //TransitionManager.Instance().Transition("CrowCrypt", transition, loadDelay);
        }

        if (DataPlayer.Instance.caranchoLost == true)
        {
            DataPlayer.Instance.caranchoLost = false;
            SceneManager.LoadScene("CaranchoCrypt");
            //TransitionManager.Instance().Transition("CaranchoCrypt", transition, loadDelay);
        }
    }
}
