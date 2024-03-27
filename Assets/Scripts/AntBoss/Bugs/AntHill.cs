using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AntHill : MonoBehaviour
{
    [SerializeField] private GameObject Orb;
    private int count;
    
    private void OnEnable()
    {
        Orb.SetActive(false);
        count = 0;
        float PosX = -9f;
        gameObject.transform.DOMoveX(PosX, 2.5f).SetLoops(4, LoopType.Restart).OnStepComplete(() => Count());
    }

    private void Count(){
        count++;
        if (count >= 3)
        {
            Orb.SetActive(true);
        }

    }
}
