using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.blue;
        gameObject.GetComponent<Animator>().SetTrigger("Platform");
    }
    public void ActiveStateObjPlat(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
