using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedFoxyAnimation : MonoBehaviour
{
    public Animator animator;
    public bool wakeIsTrue;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WakeIsTrue()
    {

        if (wakeIsTrue)
        {
            animator.SetBool("WakeIsTrue", wakeIsTrue);
        }
    }
}
