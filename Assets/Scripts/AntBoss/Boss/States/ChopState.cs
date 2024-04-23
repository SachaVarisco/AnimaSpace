using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    [Header("State object")]
    public GameObject StateObj;
    
    [Header("Timer")]
    private  float timer = 2f;
    private float currentTime;
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        gameObject.GetComponent<Animator>().SetTrigger("Chop");
        //currentTime = timer;
    }
    /*private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }*/
    public void ActiveStateObjChop(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
