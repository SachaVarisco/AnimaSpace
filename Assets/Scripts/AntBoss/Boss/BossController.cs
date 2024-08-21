using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour
{
    [Header ("Components")]
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
}
