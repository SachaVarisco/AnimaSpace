using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawnState : MonoBehaviour
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
    private void OnEnable()
    {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Animator>().SetTrigger("Attack3");
        ActiveStateObjCrawn();
    }
    public void ActiveStateObjCrawn()
    {
        StateObj.SetActive(true);
    }
    private void OnDisable()
    {
        StateObj.SetActive(false);
    }
}
