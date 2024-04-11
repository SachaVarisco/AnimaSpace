using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObjects : MonoBehaviour
{
    [Header ("Trigger")]
    [SerializeField] private bool EndTrigger;

    [Header ("Same Position?")]
    [SerializeField] private bool SamePosX;
    [SerializeField] private bool SamePosY;

    [Header ("Wait")]
    [SerializeField] private float WaitTime;

    [Header ("LoopType")]
    [SerializeField] private bool Restart;
    [SerializeField] private bool Yoyo;

    [Header ("ToMovePosition")]
    [SerializeField]  private Transform ToMovePos;
    [SerializeField] private float PosY;
    [SerializeField] private float PosX;
    private Vector2  _ToMovePos;

    [Header ("Vars")]
    [SerializeField] private float LoopTime;
    [SerializeField] private int Loops;

    [Header ("Advice")]
    [SerializeField] private bool AlertTrig;
    private GameObject Alert;

    [Header ("ComeBack")]
    private Vector2 PosInit;

    private void Awake(){
        PosInit = gameObject.transform.position;
    }
    private void OnEnable() {
        if (AlertTrig)
        {
            Alert = transform.GetChild(0).gameObject;
            Alert.SetActive(true);
        }
        PosX = ToMovePos.position.x;
        PosY = ToMovePos.position.y;
        _ToMovePos = new Vector2 (PosX,PosY);
        
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
        transform.DOMove(new Vector2 (PosX, PosY), LoopTime).SetLoops(Loops, LoopType.Restart).OnComplete(() => PassState());
    }
    private void TypeYoyo(){
        transform.DOMove(new Vector2 (PosX, PosY), LoopTime).SetLoops(Loops, LoopType.Yoyo).OnComplete(() => PassState());
    }

    private IEnumerator Wait(){
        yield return new WaitForSeconds(WaitTime);
       if (AlertTrig)
        {
            Alert.SetActive(false);
        }
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerLifeController>().Rebound(other.GetContact(0).normal);
        }
    }
    private void PassState(){
        if (EndTrigger)
        {
            transform.parent.gameObject.transform.parent.gameObject.GetComponent<StateMachine>().ActiveSeqState();
        }
    }
    private void OnDisable() {
        gameObject.transform.position = PosInit;
    }
}