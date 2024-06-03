// using System;
// using UnityEngine;

// public class FeatherMovementNotifier : MonoBehaviour
// {
//     private FeatherControl featherControl;
//     public bool IsMovementComplete { get; private set; }

//     public void Initialize(FeatherControl control) {
//         featherControl = control;
//         IsMovementComplete = false;
//     }

//     public void StartMovement() {
//         IsMovementComplete = false;
//         // Suponer que MoveObjects ya se encarga de iniciar el movimiento al activarse
//         MoveObjects moveObjects = GetComponent<MoveObjects>();
//         moveObjects.OnComplete += OnMovementComplete;
//         moveObjects.enabled = true;
//     }

//     private void OnMovementComplete() {
//         IsMovementComplete = true;
//         featherControl.OnFeatherMovementComplete();
//     }

//     private void OnDisable() {
//         MoveObjects moveObjects = GetComponent<MoveObjects>();
//         moveObjects.OnComplete -= OnMovementComplete;
//     }
// }
