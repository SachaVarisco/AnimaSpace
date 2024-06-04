using System.Collections;
using UnityEngine;


public class FeatherControl : MonoBehaviour
{
    private int currentFeatherIndex = 0;

    private void OnEnable()
    {
        StartCoroutine(ActivateFeathersOneByOne());
    }

    private IEnumerator ActivateFeathersOneByOne()
    {
        while (currentFeatherIndex < transform.childCount)
        {
            GameObject feather = transform.GetChild(currentFeatherIndex).gameObject;
            FeatherMovementNotifier notifier = feather.GetComponent<FeatherMovementNotifier>();

            // Espera a que la pluma anterior haya completado su movimiento antes de activar la siguiente
            if (currentFeatherIndex > 0)
            {
                GameObject previousFeather = transform.GetChild(currentFeatherIndex - 1).gameObject;
                FeatherMovementNotifier previousNotifier = previousFeather.GetComponent<FeatherMovementNotifier>();
                yield return new WaitUntil(() => previousNotifier.IsMovementComplete);
            }

            // Activa la pluma actual y espera a que complete su movimiento
            feather.SetActive(true);
            notifier.StartMovement();

            yield return new WaitUntil(() => notifier.IsMovementComplete);

            // Desactiva la pluma una vez que ha completado su movimiento
            feather.SetActive(false);

            currentFeatherIndex++;
        }

        // Cuando todas las plumas han completado su movimiento, reinicia el índice para futuros usos
        currentFeatherIndex = 0;
    }
}
