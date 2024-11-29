using UnityEngine;
using System;

public class CrawnMovementNotifier : MonoBehaviour
{
    public event Action OnMovementComplete; // Evento que se activa cuando el cangrejo completa su movimiento

    private MoveObjects2 moveObjects;
    private bool isMovementComplete = false;
    private Animator animator; // Referencia al componente Animator
    private bool CrawnClose = false;

    [SerializeField] private Collider2D collider1; // Primer Collider
    [SerializeField] private Collider2D collider2; // Segundo Collider

    private void Awake()
    {
        moveObjects = GetComponent<MoveObjects2>();
        animator = GetComponent<Animator>(); // Obtener la referencia al componente Animator

        if (moveObjects == null)
        {
            //Debug.LogError("MoveObjects2 component is missing on the crawn object.");
        }
    }

    private void OnEnable()
    {
        isMovementComplete = false; // Resetear el estado de movimiento
        UpdateColliders(); // Actualizar el estado de los Colliders
    }

    private void Update()
    {
        animator.SetBool("CrawnClose", CrawnClose);
    }

    private void OnFirstLoopCompleteHandler()
    {
        CrawnClose = true;
        UpdateColliders(); // Actualizar el estado de los Colliders
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

    private void OnMovementCompleteInternal()
    {
        CrawnClose = false;
        isMovementComplete = true; // Actualiza el estado de IsMovementComplete
        OnMovementComplete?.Invoke(); // Activa el evento OnMovementComplete
        UpdateColliders(); // Actualizar el estado de los Colliders
    }

    private void UpdateColliders()
    {
        if (CrawnClose)
        {
            collider1.enabled = true;
            collider2.enabled = false;
        }
        else
        {
            collider1.enabled = false;
            collider2.enabled = true;
        }
    }

    public bool IsMovementComplete => isMovementComplete; // Propiedad para acceder al estado de movimiento

    private void OnDisable()
    {
        if (moveObjects != null)
        {
            moveObjects.OnFirstLoopComplete -= OnFirstLoopCompleteHandler;
            moveObjects.OnComplete -= OnMovementCompleteInternal;
        }
    }
}
