using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PillarAnt : MonoBehaviour
{
    public float PosY;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOMoveY(PosY, 1).SetLoops(2, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
