using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowStunnedState : MonoBehaviour
{
    #region Timer
    private  float timer = 3;
    private float currentTime;
    private bool CanPass;
    #endregion
    private void OnEnable() {
        gameObject.GetComponent<Animator>().SetTrigger("Stunned");
        currentTime = timer;
    }
    private void FixedUpdate() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            ActiveIdleAgain();
            currentTime = timer;
        }
    }

    private void ActiveIdleAgain(){
        GetComponent<CrowControl>().StartCoroutine("WaitInIdle");
    }
}
