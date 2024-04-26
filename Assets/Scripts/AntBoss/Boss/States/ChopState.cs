using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    [Header("State object")]
    public GameObject StateObj;
    
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        gameObject.GetComponent<Animator>().SetTrigger("Chop");
    }
    public void ActiveStateObjChop(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
