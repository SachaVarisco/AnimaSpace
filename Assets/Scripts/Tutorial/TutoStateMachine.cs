using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStateMachine : MonoBehaviour
{
    private int StateCount;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(StateCount).gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void PassState(){
        transform.GetChild(StateCount).gameObject.SetActive(false);
        StateCount++;
        if (StateCount == 3)
        {
            GameObject canva = GameObject.FindGameObjectWithTag("Canva");
            GameObject bar = canva.transform.GetChild(0).gameObject;
            bar.SetActive(true);
        }
        transform.GetChild(StateCount).gameObject.SetActive(true);
    }
}
