using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPool : MonoBehaviour
{
    [SerializeField] private GameObject[] Eggs;
    private int EggCount;
    void OnEnable()
    {
        Eggs[EggCount].SetActive(true);
    }

    public void ReturnEgg(GameObject Egg){
        Egg.SetActive(false);
        if (EggCount < 2)
        {
            EggCount++;
            Eggs[EggCount].SetActive(true);
        }else{
            //PassState
            transform.parent.gameObject.GetComponent<CrowControl>().StartCoroutine("WaitInIdle");
            //Debug.Log("PassState");
        }
    }
    private void OnDisable() {
        EggCount = 0;
    }
}
