using UnityEngine;
using System;

public class CrawnMovementNotifier : MonoBehaviour
{
    public event Action OnMovementComplete; // Evento que se activa cuando la pluma completa su movimiento

    private MoveObjects2 moveObjects;
    private bool isMovementComplete = false;
    private Animator animator; // Referencia al componente Animator
    private bool CrawnClose = false;

    private void Awake()
    {
        moveObjects = GetComponent<MoveObjects2>();
        animator = GetComponent<Animator>(); // Obtener la referencia al componente Animator
        if (moveObjects == null)
        {
            Debug.LogError("MoveObjects2 component is missing on the feather object.");
        }
    }

    public void StartMovement()
    {
        if (moveObjects != null)
        {
            moveObjects.OnFirstLoopComplete += OnFirstLoopCompleteHandler;
            moveObjects.OnComplete += OnMovementCompleteInternal;
            moveObjects.enabled = true;
        }
    }

    private void Update(){

        animator.SetBool("CrawnClose", CrawnClose);
    }

    private void OnFirstLoopCompleteHandler()
    {
        CrawnClose = true;
    }

    private void OnMovementCompleteInternal()
    {
        isMovementComplete = true; // Actualiza el estado de IsMovementComplete
        OnMovementComplete?.Invoke(); // Activa el evento OnMovementComplete
    }

    public bool IsMovementComplete => isMovementComplete; // Propiedad para acceder al estado de movimiento

    private void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("PlayAnimationTrigger"); // Asume que tienes un trigger en tu Animator llamado "PlayAnimationTrigger"
        }
        else
        {
            Debug.LogError("Animator component is missing on the feather object.");
        }
    }

    private void OnDisable()
    {
        if (moveObjects != null)
        {
            moveObjects.OnFirstLoopComplete -= OnFirstLoopCompleteHandler;
            moveObjects.OnComplete -= OnMovementCompleteInternal;
        }
    }
}
