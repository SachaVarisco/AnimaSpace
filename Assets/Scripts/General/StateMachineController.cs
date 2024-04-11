using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header ("States")]
    public MonoBehaviour[] stateArray;
    private MonoBehaviour ActualState;
    private MonoBehaviour NextState;
    private MonoBehaviour IdleState;
    private int StateCount;

    [Header ("OrbSpawns")]
    [SerializeField] private GameObject Orb;

    private void Start()
    {
        StateCount = 1;
        IdleState = stateArray[0];
        ActivateState(IdleState);
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
            ActivateState(stateArray[1]);
        }else{
            ActivateState(NextState);
        }
        StartCoroutine("SpawnOrb");
    }

    public void ActiveSeqState(){ 
        Orb.SetActive(false);
        StateCount++;
        NextState = stateArray[StateCount];
        if (StateCount >= 6)
        {
            StateCount = 1;
            NextState = stateArray[StateCount];
            ActivateState(IdleState);
        }else {
            ActivateState(IdleState);
        }
    }

    public void ActiveStun(){
        ActualState.enabled = false; 
        ActualState = stateArray[6];
        StateCount++;
        NextState = stateArray[StateCount];
        ActualState.enabled = true;
    }
    public void ActiveIdle(){
        ActivateState(IdleState);
    }

    private IEnumerator SpawnOrb(){
        yield return new WaitForSeconds(3);
        if (ActualState != stateArray[3])
        {
            Orb.SetActive(true);
        }
    }
}