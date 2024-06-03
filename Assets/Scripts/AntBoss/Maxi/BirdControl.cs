using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    private int Child;
    private GameObject Bird;
    //private MoveObjects currentMoveObject;

    private void OnEnable() {
        Child = 0; // Inicializar el índice de la pluma
        ActivateNextBird();
    }

    private void ActivateNextBird() {
        if (Child < transform.childCount) {
            Bird = transform.GetChild(Child).gameObject;
            Bird.SetActive(true);

            // Obtener el componente MoveObjects y asignar el callback OnComplete
            // currentMoveObject = Bird.GetComponent<MoveObjects>();
            // currentMoveObject.OnComplete += HandleBirdReachedDestination;
        }
        else {
            Child = 0;
            transform.parent.gameObject.GetComponent<StateMachine>().PassState();
        }
    }

    private void HandleBirdReachedDestination() {
        // Desactivar la pluma actual
        Bird.SetActive(false);

        // Activar la siguiente pluma
        Child++;
        ActivateNextBird();
    }

    // private void OnDisable() {
    //     if (currentMoveObject != null) {
    //         currentMoveObject.OnComplete -= HandleBirdReachedDestination;
    //     }
    // }
}