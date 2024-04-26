using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header ("States")]
    //private bool canPassState;
    public MonoBehaviour[] stateArray;
    private MonoBehaviour ActualState;
    private MonoBehaviour NextState;
    [SerializeField] private MonoBehaviour StunnedState;
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
        
    }

    private void ActiveSeqState(){
        StateCount++;
        int index = Random.Range(0,stateArray.Length);
        if(StateCount <= 3){
            //canPassState = false;
            if (ActualState == stateArray[index])
            {
                index = Random.Range(0,stateArray.Length);
                ActivateState(stateArray[index]);
            }else {
                ActivateState(stateArray[index]);
            }
        }else{ 
            
            StateCount = 0;
            ActivateState(StunnedState);
            StartCoroutine("SpawnOrb");
        }
        
    }

    /*public void ActiveSeqState(){ 
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
    }*/

    /*public void ActiveStun(){
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
    }*/
    public IEnumerator WaitInIdle(){
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(2);
        if (StateCount == 0)
        {
            ActiveSeqState();
        }
    }

    private IEnumerator SpawnOrb(){
        Orb.SetActive(true);
        yield return new WaitForSeconds(3);
        Orb.SetActive(false);
    }

    public void PassState(){
        ActiveSeqState();
    }
}