using UnityEngine;
using System;

public class BirdMovementNotifier : MonoBehaviour
{
    public event Action OnMovementComplete; // Evento que se activa cuando la pluma completa su movimiento

    private MoveObjects2 moveObjects;
    private bool isMovementComplete = false;
    //private Vector3 initialPosition; // Variable para almacenar la posición inicial

    private void Awake()
    {
        moveObjects = GetComponent<MoveObjects2>();
        if (moveObjects == null)
        {
            Debug.LogError("MoveObjects2 component is missing on the feather object.");
        }

        //initialPosition = transform.position; // Guardar la posición inicial
    }

    private void OnEnable()
    {
        isMovementComplete = false; // Resetear el estado de movimiento
        //transform.position = initialPosition; // Volver a la posición inicial
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
        isMovementComplete = true; // Actualiza el estado de isMovementComplete
        OnMovementComplete?.Invoke(); // Activa el evento OnMovementComplete
        moveObjects.enabled = false; // Desactivar el script después del movimiento
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
