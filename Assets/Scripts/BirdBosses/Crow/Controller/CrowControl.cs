using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CrowControl : MonoBehaviour
{
    [Header("States")]
    public int StateCount;
    [SerializeField] private MonoBehaviour BallState;
    [SerializeField] private MonoBehaviour EggState;
    [SerializeField] private MonoBehaviour StunnedState;
    private MonoBehaviour ActualState;
    

    [Header("OrbSpawns")]
    [SerializeField] private GameObject Orb;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] AudioClip Attack;
    [SerializeField] AudioClip Damaged;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StateCount = 0;
        StartCoroutine("WaitInIdle");
    }

    private void ActivateState(MonoBehaviour newState)
    {
        if (ActualState != null)
        {
            ActualState.enabled = false;
        }
        ActualState = newState;
        ActualState.enabled = true;
        audioSource.PlayOneShot(Attack);
    }

    public void ChangeState()
    {
        Debug.Log("State "+ StateCount);
        if (StateCount == 2)
        {
            StateCount = 0;
            Debug.Log("Stun");
            Stunned();
        }else if (StateCount == 0)
        {
            Debug.Log("Egg");
            ActivateState(EggState);
        }
        else
        {
            Debug.Log("Ball");
            ActivateState(BallState);
        }
    }

    public void Stunned()
    {
        ActivateState(StunnedState);
        audioSource.PlayOneShot(Damaged);
        StartCoroutine("SpawnOrb");
    }
    public IEnumerator WaitInIdle()
    {
        yield return new WaitForSeconds(2);
        ChangeState();
    }

    private IEnumerator SpawnOrb()
    {
        Orb.SetActive(true);
        yield return new WaitForSeconds(4);
        Orb.SetActive(false);
    }
}
