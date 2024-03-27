using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public MonoBehaviour[] stateArray;
    private MonoBehaviour ActualState;

    private void Start()
    {
        ActivateState(stateArray[0]);
    }
    public void ActivateState(MonoBehaviour newState){
        if (ActualState != null)
        {
            ActualState.enabled = false; 
        }
        ActualState = newState;
        ActualState.enabled = true;
    }
}