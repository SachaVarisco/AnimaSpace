using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AntHill : MonoBehaviour
{
    [SerializeField] private GameObject Orb;

    private void OnEnable()
    {
        Orb.SetActive(false);
        float PosX = -9f;
        gameObject.transform.DOMoveX(PosX, 2.5f).SetLoops(4, LoopType.Restart);
    }
}
