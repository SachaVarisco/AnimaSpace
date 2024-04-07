using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour
{
    [Header ("States")]
    [SerializeField] private GameObject[] States;
    private int Element;
    private GameObject ActualState;

    [Header ("OrbSpawns")]
    [SerializeField] private GameObject Orb;
    [SerializeField] private Transform[] Spawns;
    [SerializeField] private int StateNoSpawn;

    [Header ("Components")]
    private Animator Animator;
    private void Awake() {
        States[Element].SetActive(true);
        ActualState = States[Element];
        SpawnOrb();
    }
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void ActiveSeqStates(){
        ActualState.SetActive(false);
        Element++;
        if (Element >= 6)
        {
            Element = 1;
        }
        ActualState = States[Element];
        ActualState.SetActive(true);
    }
    private void ActiveRandState(){
        ActualState.SetActive(false);
        int index = Random.Range(0, States.Length);
        GameObject newState = States[index];
        if (newState != ActualState)
        {
            States[index].SetActive(true);
        }else{
            
        }
    }
    private IEnumerator SpawnOrb(){
        if (Element != StateNoSpawn)
        {
            yield return new WaitForSeconds(1f);
            Orb.SetActive(true); 
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
