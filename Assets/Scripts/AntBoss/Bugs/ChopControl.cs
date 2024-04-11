using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopControl : MonoBehaviour
{
    
    private int Child;
    private GameObject Chop;
    private void OnEnable() {
        ActiveHead();
    }

    private void ActiveHead(){
        if (Child <= 2)
        {
            Chop = transform.GetChild(Child).gameObject;
            Chop.SetActive(true);
        }else{
            Child = 0;
            transform.parent.gameObject.GetComponent<StateMachine>().ActiveSeqState();
        }
    }
    public void NewHead(){
        Chop.SetActive(false);
        Child++;
        ActiveHead();
    }
}
