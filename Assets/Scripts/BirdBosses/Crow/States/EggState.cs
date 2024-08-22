using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggState : MonoBehaviour
{
   [Header("State object")]
    [SerializeField] GameObject StateObj;
    private void OnEnable() {
        gameObject.GetComponent<Animator>().SetTrigger("Egg");
        GetComponent<CrowControl>().StateCount++;
        //ActiveStateEgg();
    }
    public void ActiveStateEgg(){
        StateObj.SetActive(true);
    }
    private void OnDisable() {
        StateObj.SetActive(false);
    }
}
