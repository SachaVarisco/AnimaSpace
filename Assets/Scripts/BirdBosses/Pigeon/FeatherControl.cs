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
        // Activa todas las plumas al principio
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

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
