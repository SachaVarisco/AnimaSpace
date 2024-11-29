using System.Collections;
using UnityEngine;


public class BirdControl : MonoBehaviour
{
    private int currentBirdIndex = 0;

    private void OnEnable()
    {
         //Debug.Log("inicial " + currentBirdIndex);
        currentBirdIndex = 0;
        StartCoroutine(ActivateBirdsOneByOne());
    }

    private IEnumerator ActivateBirdsOneByOne()
    {
        while (currentBirdIndex < transform.childCount)
        {
             //Debug.Log("intermedio " + currentBirdIndex);

            GameObject Bird = transform.GetChild(currentBirdIndex).gameObject;
            BirdMovementNotifier notifier = Bird.GetComponent<BirdMovementNotifier>();

            // Espera a que la pluma anterior haya completado su movimiento antes de activar la siguiente
            // if (currentBirdIndex > 0)
            // {
            //     GameObject previousBird = transform.GetChild(currentBirdIndex - 1).gameObject;
            //     BirdMovementNotifier previousNotifier = previousBird.GetComponent<BirdMovementNotifier>();
            //     yield return new WaitUntil(() => previousNotifier.IsMovementComplete);
            // }

            // Activa la pluma actual y espera a que complete su movimiento
            Bird.SetActive(true);
            notifier.StartMovement();
            notifier.OnMovementComplete += () => Bird.SetActive(false);

            yield return new WaitUntil(() => notifier.IsMovementComplete);

            // Desactiva la pluma una vez que ha completado su movimiento
            //Bird.SetActive(false);

            currentBirdIndex++;
        }

        // Cuando todas las plumas han completado su movimiento, reinicia el índice para futuros usos
        //Debug.Log("final " + currentBirdIndex);
        currentBirdIndex = 0;
    }
}

