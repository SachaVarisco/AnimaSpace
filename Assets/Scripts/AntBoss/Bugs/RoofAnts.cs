using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoofAnts : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        float PosY = 0.72f;
        gameObject.transform.DOMoveY(PosY, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
