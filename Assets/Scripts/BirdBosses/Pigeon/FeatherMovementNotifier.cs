using System;
using UnityEngine;

public class FeatherMovementNotifier : MonoBehaviour
{
    public event Action OnMovementComplete; // Evento que se activa cuando la pluma completa su movimiento

    private MoveObjects2 moveObjects;
    private bool isMovementComplete = false;

    private void Awake()
    {
        moveObjects = GetComponent<MoveObjects2>();
        if (moveObjects == null)
        {
             //Debug.LogError("MoveObjects2 component is missing on the feather object.");
        }
    }

    private void OnEnable()
    {
        StartMovement();
    }

    public void StartMovement()
    {
        if (moveObjects != null)
        {
            moveObjects.OnComplete += OnMovementCompleteInternal;
            moveObjects.enabled = true;
        }
    }

    private void OnMovementCompleteInternal()
    {
        isMovementComplete = true; // Actualiza el estado de IsMovementComplete
        OnMovementComplete?.Invoke(); // Activa el evento OnMovementComplete
    }

    public bool IsMovementComplete => isMovementComplete; // Propiedad para acceder al estado de movimiento

    private void OnDisable()
    {
        if (moveObjects != null)
        {
            moveObjects.OnComplete -= OnMovementCompleteInternal;
        }
    }
}
