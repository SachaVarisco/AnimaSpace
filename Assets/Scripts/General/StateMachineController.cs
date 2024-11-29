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

    [Header("Audio")]
    [SerializeField] AudioClip Attack;
    [SerializeField] AudioClip Damaged;

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
        AudioControll.Instance.PlaySound(Attack);
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
            AudioControll.Instance.PlaySound(Damaged);
            StartCoroutine("SpawnOrb");
        }
        
    }

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
        yield return new WaitForSeconds(4);
        Orb.SetActive(false);
    }

    public void PassState(){
        ActiveSeqState();
    }
}