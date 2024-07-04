using System.Collections;
using UnityEngine;


public class BirdControl : MonoBehaviour
{
    private int currentBirdIndex = 0;

    private void OnEnable()
    {
        StartCoroutine(ActivateBirdsOneByOne());
    }

    private IEnumerator ActivateBirdsOneByOne()
    {
        while (currentBirdIndex < transform.childCount)
        {
            GameObject Bird = transform.GetChild(currentBirdIndex).gameObject;
            BirdMovementNotifier notifier = Bird.GetComponent<BirdMovementNotifier>();

            // Espera a que la pluma anterior haya completado su movimiento antes de activar la siguiente
            if (currentBirdIndex > 0)
            {
                GameObject previousBird = transform.GetChild(currentBirdIndex - 1).gameObject;
                BirdMovementNotifier previousNotifier = previousBird.GetComponent<BirdMovementNotifier>();
                yield return new WaitUntil(() => previousNotifier.IsMovementComplete);
            }

            // Activa la pluma actual y espera a que complete su movimiento
            Bird.SetActive(true);
            notifier.StartMovement();

            yield return new WaitUntil(() => notifier.IsMovementComplete);

            // Desactiva la pluma una vez que ha completado su movimiento
            Bird.SetActive(false);

            currentBirdIndex++;
        }

        // Cuando todas las plumas han completado su movimiento, reinicia el índice para futuros usos
        currentBirdIndex = 0;
    }
}

