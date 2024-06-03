using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherControl : MonoBehaviour
{
    private int Child;
    private GameObject Feather;
    //private MoveObjects currentMoveObject;

    private void OnEnable() {
        Child = 0; // Inicializar el índice de la pluma
        ActivateNextFeather();
    }

    private void ActivateNextFeather() {
        if (Child < transform.childCount) {
            Feather = transform.GetChild(Child).gameObject;
            Feather.SetActive(true);

            // Obtener el componente MoveObjects y asignar el callback OnComplete
            // currentMoveObject = Feather.GetComponent<MoveObjects>();
            // currentMoveObject.OnComplete += HandleFeatherReachedDestination;
        }
        else {
            Debug.LogWarning("a2");
            Child = 0;
            transform.parent.gameObject.GetComponent<StateMachine>().PassState();
        }
    }

    private void HandleFeatherReachedDestination() {
        // Desactivar la pluma actual
        Feather.SetActive(false);

        // Activar la siguiente pluma
        Child++;
        ActivateNextFeather();
    }

    // private void OnDisable() {
    //     if (currentMoveObject != null) {
    //         currentMoveObject.OnComplete -= HandleFeatherReachedDestination;
    //     }
    // }
}