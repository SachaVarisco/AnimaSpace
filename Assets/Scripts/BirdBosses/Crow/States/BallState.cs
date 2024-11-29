using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallState : MonoBehaviour
{
    [Header("State object")]
    [SerializeField] GameObject StateObj;

    private void OnEnable() {
        gameObject.GetComponent<Animator>().SetTrigger("Ball");
        GetComponent<CrowControl>().StateCount++;
        //ActiveStateBalls();
    }
    public void ActiveStateBalls(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
