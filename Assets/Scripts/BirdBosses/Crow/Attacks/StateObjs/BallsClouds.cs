using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsClouds : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float maxTime;
    private float currentTime;
    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0){
            transform.parent.gameObject.GetComponent<CrowControl>().StartCoroutine("WaitInIdle");
            currentTime = maxTime;
        }
    }

    
}
