using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoombaPhase : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] private GameObject StateObj;

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Timer")]
    private  float timer = 2f;
    private float currentTime;
    void Start()
    {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        gameObject.GetComponent<Animator>().SetTrigger("Goomba");
        currentTime = timer;
    }
    /*private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }*/
    public void ActiveStateObjGoom(){
        StateObj.transform.GetChild(0).gameObject.SetActive(true);
        StateObj.transform.GetChild(1).gameObject.SetActive(true);
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.transform.GetChild(0).gameObject.SetActive(false);
        StateObj.transform.GetChild(1).gameObject.SetActive(false);
        StateObj.SetActive(false);
    }
}
