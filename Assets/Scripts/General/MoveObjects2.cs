using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoveObjects2 : MonoBehaviour
{
    [Header("Trigger")]
    [SerializeField] private bool EndTrigger;

    [Header("Same Position?")]
    [SerializeField] private bool SamePosX;
    [SerializeField] private bool SamePosY;

    [Header("Wait")]
    [SerializeField] private float WaitTime;

    [Header("LoopType")]
    [SerializeField] private bool Restart;
    [SerializeField] private bool Yoyo;

    [Header("ToMovePosition")]
    [SerializeField] private Transform ToMovePos;
    [SerializeField] private float PosY;
    [SerializeField] private float PosX;
    private Vector2 _ToMovePos;

    [Header("Vars")]
    [SerializeField] private float LoopTime;
    [SerializeField] private int Loops;

    [Header("Advice")]
    [SerializeField] private bool AlertTrig;
    private GameObject Alert;

    [Header("ComeBack")]
    private Vector2 PosInit;

    public Action OnComplete;

    //private bool isMovementComplete = false;

    private void Awake()
    {
        PosInit = gameObject.transform.position;

        // Desactiva el script al principio para evitar que las plumas se muevan automáticamente
        enabled = false;
    }

    private void OnEnable()
    {
        if (AlertTrig)
        {
            Alert = transform.GetChild(0).gameObject;
            Alert.SetActive(true);
        }
        PosX = ToMovePos.position.x;
        PosY = ToMovePos.position.y;
        _ToMovePos = new Vector2(PosX, PosY);

        StartCoroutine("Wait");
    }

    private void Update(){

        if (ToMovePos == null)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        float distanceToTarget = Vector2.Distance(transform.position, new Vector2(PosX, PosY));
        float moveDuration = LoopTime * (distanceToTarget / 10f); // Ajustar el divisor para cambiar la velocidad

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
            TypeRestart(moveDuration);
        }

        if (Yoyo && !Restart)
        {
            TypeYoyo(moveDuration);
        }

        if (!Yoyo && !Restart)
        {
            transform.DOMove(new Vector2(PosX, PosY), moveDuration).OnComplete(() =>
            {
                OnComplete?.Invoke(); // Llamar al evento OnComplete
                PassState();
            });
        }
    }

    private void TypeRestart(float duration)
    {
        transform.DOMove(new Vector2(PosX, PosY), duration).SetLoops(Loops, LoopType.Restart).OnComplete(() =>
        {
            OnComplete?.Invoke(); // Llamar al evento OnComplete
            PassState();
        });
    }

    private void TypeYoyo(float duration)
    {
        transform.DOMove(new Vector2(PosX, PosY), duration).SetLoops(Loops, LoopType.Yoyo).OnComplete(() =>
        {
            OnComplete?.Invoke(); // Llamar al evento OnComplete
            PassState();
        });
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(WaitTime);
        if (AlertTrig)
        {
            Alert.SetActive(false);
        }
        // Activa el script solo cuando se inicie el movimiento de la pluma
        enabled = true;

        // Comienza el movimiento de la pluma
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLifeController>().Rebound(other.GetContact(0).normal);
        }
    }

    private void PassState()
    {
        if (EndTrigger)
        {
            DataPlayer.Instance.PigeonCount++;
            SceneData.Instance.Pigeon();
        }
    }

    private void OnMovementCompleteInternal()
    {
        OnComplete?.Invoke(); // Llamar al evento OnComplete

        // Desactiva el script después de que la pluma ha completado su movimiento
        enabled = false;

        PassState();
    }

    private void OnDisable()
    {
        gameObject.transform.position = PosInit;
    }
}
