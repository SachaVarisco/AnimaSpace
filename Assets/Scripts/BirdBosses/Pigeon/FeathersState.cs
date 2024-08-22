using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeathersState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] private GameObject StateObj;

    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    private void OnEnable() {
        Debug.LogWarning("FeathersState OnEnable");
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        gameObject.GetComponent<Animator>().SetTrigger("Attack2");
        //ActiveStateObjGoom();
    }

    public void ActiveStateObjGoom(){
        Debug.LogWarning("Activando FeathersState Obj");
        StateObj.SetActive(true);
    }

    private void OnDisable() {
        Debug.LogWarning("Desactivando FeathersState Obj");
        StateObj.SetActive(false);
    }
}
