using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    [Header("Timer")]
    private  float timer = 1.5f;
    private float currentTime;
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.blue;
        gameObject.GetComponent<Animator>().SetTrigger("Platform");
        currentTime = timer;
    }
    /*private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Wait();
        }
    }*/
    public void ActiveStateObjPlat(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
