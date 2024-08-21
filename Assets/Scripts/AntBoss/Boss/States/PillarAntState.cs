using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAntState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    [Header("StateMachine")]

    [SerializeField] private GameObject StateIndicator;

    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.cyan;
        gameObject.GetComponent<Animator>().SetTrigger("Pillar");
    }
    public void ActiveStateObjPill(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
