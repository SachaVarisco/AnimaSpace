using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoombaPhase : MonoBehaviour
{
    [Header("Bug")]
    //[SerializeField] private GoombaBug Bug;

   

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float SpawnTime;
    void Start()
    {
        currentTime = SpawnTime;
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        Spawn();
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
           currentTime = SpawnTime; 
        }
    }

    private void Spawn(){
        Pool.Instance.RequestPrefab();
    }
}
