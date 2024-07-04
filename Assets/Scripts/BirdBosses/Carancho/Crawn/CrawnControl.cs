using System.Collections;
using UnityEngine;


public class CrawnControl : MonoBehaviour
{
    private int currentCrawnIndex = 0;

    private void OnEnable()
    {
        StartCoroutine(ActivateCrawnsOneByOne());
    }

    private IEnumerator ActivateCrawnsOneByOne()
    {
        while (currentCrawnIndex < transform.childCount)
        {
            GameObject Crawn = transform.GetChild(currentCrawnIndex).gameObject;
            CrawnMovementNotifier notifier = Crawn.GetComponent<CrawnMovementNotifier>();

            // Espera a que la pluma anterior haya completado su movimiento antes de activar la siguiente
            if (currentCrawnIndex > 0)
            {
                GameObject previousCrawn = transform.GetChild(currentCrawnIndex - 1).gameObject;
                CrawnMovementNotifier previousNotifier = previousCrawn.GetComponent<CrawnMovementNotifier>();
                yield return new WaitUntil(() => previousNotifier.IsMovementComplete);
            }

            // Activa la pluma actual y espera a que complete su movimiento
            Crawn.SetActive(true);
            notifier.StartMovement();

            yield return new WaitUntil(() => notifier.IsMovementComplete);

            // Desactiva la pluma una vez que ha completado su movimiento
            Crawn.SetActive(false);

            currentCrawnIndex++;
        }

        // Cuando todas las plumas han completado su movimiento, reinicia el índice para futuros usos
        currentCrawnIndex = 0;
    }
}

