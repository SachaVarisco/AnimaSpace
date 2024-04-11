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
        Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<BarController>();
    }
    private void OnEnable() {
        Bar.Orb();
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.gray;
        gameObject.GetComponent<Animator>().SetTrigger("Stunned");
        currentTime = timer;
    }
    private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            GetComponent<StateMachine>().ActiveIdle();
        }
    }
}
