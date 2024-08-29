using UnityEngine;
using UnityEngine.EventSystems;
using EasyTransition;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIContinueButton : MonoBehaviour
{
    private Button button;
    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        StartCoroutine("Wait");
    }

    private void OnButtonClicked(){
        SceneManager.LoadScene("Lotor");
        //TransitionManager.Instance().Transition("Lotor", transition, loadDelay);
    }
    
    private IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
