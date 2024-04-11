using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopState : MonoBehaviour
{
    [Header("StateMachine")]
    [SerializeField] private GameObject StateIndicator;

    [Header("State object")]
    public GameObject StateObj;
    //[Header("Heads")]
    //[SerializeField] private GameObject[] Heads;
    
    
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        gameObject.GetComponent<Animator>().SetTrigger("Chop");
        StartCoroutine("Wait");
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
