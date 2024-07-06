using System.Collections;
using UnityEngine;

public class TornadoControl : MonoBehaviour
{
    private int currentTornadoIndex = 0;
    public float delayBetweenActivations = 1f; // Tiempo de espera entre activaciones

    private void OnEnable()
    {
        StartCoroutine(ActivateTornadosWithDelay());
    }

    private IEnumerator ActivateTornadosWithDelay()
    {
        while (currentTornadoIndex < transform.childCount)
        {
            GameObject Tornado = transform.GetChild(currentTornadoIndex).gameObject;
            TornadoMovementNotifier notifier = Tornado.GetComponent<TornadoMovementNotifier>();

            // Suscribir al evento de notificación de movimiento completo para desactivar el tornado
            notifier.OnMovementComplete += () => Tornado.SetActive(false);

            // Activa el tornado actual y empieza su movimiento
            Tornado.SetActive(true);
            notifier.StartMovement();

            currentTornadoIndex++;

            // Espera el tiempo especificado antes de activar el siguiente tornado
            yield return new WaitForSeconds(delayBetweenActivations);
        }

        // Cuando todos los tornados han completado su movimiento, reinicia el índice para futuros usos
        currentTornadoIndex = 0;
    }
}
