using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAntState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    private void Awake() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.cyan;
        gameObject.GetComponent<Animator>().SetTrigger("Pillar");
        StartCoroutine("Wait");
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
