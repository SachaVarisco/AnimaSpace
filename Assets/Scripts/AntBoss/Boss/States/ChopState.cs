using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    [Header("Heads")]
    [SerializeField] private GameObject[] Heads;
    void Start()
    {

    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    private void HeadsControl(){

    }

    /*private void ActiveSeqStates(){
        ActualState.SetActive(false);
        Element++;
        if (Element >= 6)
        {
            Element = 1;
        }
        ActualState = States[Element];
        ActualState.SetActive(true);
    }*/
}
