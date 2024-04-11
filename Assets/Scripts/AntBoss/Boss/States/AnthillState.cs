using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHillState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] private GameObject StateObj;

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Animator>().SetTrigger("AntHill");
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
