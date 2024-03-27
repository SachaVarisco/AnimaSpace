using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour
{
    [Header ("States")]
    [SerializeField] private GameObject[] States;
    private int Element;
    private GameObject ActualState;
    [Header ("Observer")]


    [Header ("Components")]
    private Animator Animator;
    private void Awake() {
        Element = 0;
        States[0].SetActive(true);
        ActualState = States[Element];
    }
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void ActiveSeqStates(){
        ActualState.SetActive(false);
        Element++;
        ActualState = States[Element];
        if (ActualState == null)
        {
            Element = 1;
            ActualState = States[Element];
        }
        ActualState.SetActive(true);
    }
    private void ActiveRandState(){
        ActualState.SetActive(false);
        int index = Random.Range(0, States.Length);
        GameObject newState = States[index];
        if (newState != ActualState)
        {
            States[index].SetActive(true);
        }
    }

    private void TakeOrb(){
        // Volver al estado Idle
        ActualState.SetActive(false);
        Element = 0;
        ActualState = States[Element];
        ActualState.SetActive(true);

        //Modificar la barra de competencia

    }
}
