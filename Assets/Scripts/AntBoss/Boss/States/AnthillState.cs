using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHillState : MonoBehaviour
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
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Animator>().SetTrigger("Anthill");
        //currentTime = timer;
    }
    /*private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }*/
    public void ActiveStateObjAntHill(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
