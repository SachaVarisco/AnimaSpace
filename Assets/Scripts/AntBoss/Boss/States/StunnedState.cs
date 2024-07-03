using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunnedState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;
    private StateMachine StateMach;

    #region Timer
    private  float timer = 3;
    private float currentTime;
    private bool CanPass;
    #endregion

    #region Canva
    private BarController Bar;
    #endregion
    private void Awake() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.gray;
        gameObject.GetComponent<Animator>().SetTrigger("Stunned");
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
        GetComponent<StateMachine>().StartCoroutine("WaitInIdle");
    }
}
