using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeathersState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] private GameObject StateObj;

    [Header("StateMachine")]
    //private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    // void Start()
    // {
    //     StateMach = GetComponent<StateMachine>();
    // }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        gameObject.GetComponent<Animator>().SetTrigger("Goomba");
    }
    public void ActiveStateObjGoom(){
        //StateObj.gameObject.SetActive(true);
        //StateObj.transform.GetChild(1).gameObject.SetActive(true);
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        //StateObj.gameObject.SetActive(false);
        //StateObj.transform.GetChild(1).gameObject.SetActive(false);
        StateObj.SetActive(false);
    }
}
