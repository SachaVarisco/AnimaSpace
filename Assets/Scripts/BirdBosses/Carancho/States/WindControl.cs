using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindControl : MonoBehaviour
{
    private StateMachine StateMach;

    #region Timer
    private  float timer = 8f;
    private float currentTime;
    private bool CanPass;
    #endregion

    private void Awake() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        currentTime = timer;
        CanPass = true;
    }
    private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && CanPass)
        {
            CanPass = false;
            ActiveIdleAgain();
        }
    }
    
    private void ActiveIdleAgain(){
        transform.parent.gameObject.GetComponent<StateMachine>().PassState();
    }
}
