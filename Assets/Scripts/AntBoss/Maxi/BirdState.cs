using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] private GameObject StateObj;

    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        //gameObject.GetComponent<Animator>().SetTrigger("Goomba");
        ActiveStateObjGoom();
    }

    public void ActiveStateObjGoom(){
        StateObj.SetActive(true);
    }

    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
