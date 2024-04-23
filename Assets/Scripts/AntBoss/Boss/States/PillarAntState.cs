using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAntState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Timer")]
    private  float timer = 1.5f;
    private float currentTime;

    private void Awake() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.cyan;
        gameObject.GetComponent<Animator>().SetTrigger("Pillar");
        currentTime = timer;
    }
    /*private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }*/
    public void ActiveStateObjPill(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
