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
    private  float timer = 2;
    private float currentTime;
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
    }
    public void ActiveIdleAgain() {
        GetComponent<StateMachine>().StartCoroutine("WaitInIdle");
    }
}
