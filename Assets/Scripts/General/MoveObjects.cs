using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObjects : MonoBehaviour
{
    [Header ("Same Position?")]
    [SerializeField] private bool SamePosX;
    [SerializeField] private bool SamePosY;

    [Header ("Wait")]
    [SerializeField] private float WaitTime;

    [Header ("LoopType")]
    [SerializeField] private bool Restart;
    [SerializeField] private bool Yoyo;

    [Header ("Position")]
    [SerializeField] private float PosY;
    [SerializeField] private float PosX;

    [Header ("Vars")]
    [SerializeField] private float LoopTime;
    [SerializeField] private int Loops;
    private void OnEnable() {
        StartCoroutine("Wait");
    }

    private void Move(){
        if (SamePosX)
        {
            PosX = transform.position.x;
        }
        if (SamePosY)
        {
            PosY = transform.position.y;
        }

        if (Restart && !Yoyo)
        {
            TypeRestart();
        }
        if (Yoyo && !Restart)
        {
            TypeYoyo();
        }
        if (!Yoyo && !Restart)
        {
            transform.DOMove(new Vector2 (PosX, PosY), LoopTime);
        }
    }
    private void TypeRestart(){
        transform.DOMove(new Vector2 (PosX, PosY), LoopTime).SetLoops(Loops, LoopType.Restart);
    }
    private void TypeYoyo(){
        transform.DOMove(new Vector2 (PosX, PosY), LoopTime).SetLoops(Loops, LoopType.Yoyo);
    }

    private IEnumerator Wait(){
        yield return new WaitForSeconds(WaitTime);
        Move();

    }
    private void PassState(){

    }
}