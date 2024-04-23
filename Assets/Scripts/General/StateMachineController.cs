using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header ("States")]
    public MonoBehaviour[] stateArray;
    private MonoBehaviour ActualState;
    private MonoBehaviour NextState;
    private int StateCount;
    [SerializeField] private GameObject StateIndicator;

    [Header ("OrbSpawns")]
    [SerializeField] private GameObject Orb;

    private void Start()
    {
        StateCount = 0;
        StartCoroutine("WaitInIdle");
    }
    private void ActivateState(MonoBehaviour newState){
        if (ActualState != null)
        {
            ActualState.enabled = false; 
        }
        ActualState = newState;
        ActualState.enabled = true;

    }

    public void ActiveNextState(){
        if (NextState == null)
        {
            ActivateState(stateArray[0]);
        }else{
            ActivateState(NextState);
        }
        StartCoroutine("SpawnOrb");
    }

    public void ActiveSeqState(){ 
        Debug.Log("SeqState");
        Orb.SetActive(false);
        StateCount++;
        NextState = stateArray[StateCount];
        if (StateCount >= 5)
        {
            StateCount = 0;
            NextState = stateArray[StateCount];
            StartCoroutine("WaitInIdle");
        }else {
            StartCoroutine("WaitInIdle");
        }
    }

    public void ActiveStun(){
        ActualState.enabled = false; 
        ActualState = stateArray[5];
        if (StateCount >= 5)
        {
            StateCount = 0;
            NextState = stateArray[StateCount];
        }else {
            StateCount++;
            NextState = stateArray[StateCount];
        }
        
        ActualState.enabled = true;
    }
    public IEnumerator WaitInIdle(){
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(2);
        ActiveNextState();
    }

    private IEnumerator SpawnOrb(){
        yield return new WaitForSeconds(3);
        if (ActualState != stateArray[2])
        {
            Orb.SetActive(true);
        }
    }
}