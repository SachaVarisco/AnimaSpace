using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;
    private StateMachine StateMach;

    [Header("Timer")]
    private  float timer = 1.5f;
    private float currentTime;
    private void Awake() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        currentTime = timer;
    }
    private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }
    private void Wait(){
        StateMach.ActiveNextState();
    }
}
