using System.Collections;
using UnityEngine;

public class CrawnControl : MonoBehaviour
{
    private void OnEnable()
    {
        Reset();
        StartCoroutine(ActivateCrawnsSimultaneously());
    }

    private IEnumerator ActivateCrawnsSimultaneously()
    {
        foreach (Transform crawnGroup in transform)
        {
            foreach (Transform crawn in crawnGroup)
            {
                GameObject crawnObject = crawn.gameObject;
                CrawnMovementNotifier notifier = crawnObject.GetComponent<CrawnMovementNotifier>();

                if (notifier != null)
                {
                    crawnObject.SetActive(true);
                    notifier.StartMovement();
                    notifier.OnMovementComplete += () => crawnObject.SetActive(false);
                }
            }
        }

        // Espera a que todos los cangrejos terminen sus movimientos
        foreach (Transform crawnGroup in transform)
        {
            foreach (Transform crawn in crawnGroup)
            {
                CrawnMovementNotifier notifier = crawn.GetComponent<CrawnMovementNotifier>();
                if (notifier != null)
                {
                    yield return new WaitUntil(() => notifier.IsMovementComplete);
                }
            }
        }

    }

    private void Reset()
    {
        // Reiniciar el índice para futuros usos
        foreach (Transform crawnGroup in transform)
        {
            foreach (Transform crawn in crawnGroup)
            {
                crawn.gameObject.SetActive(false);
            }
        }
    }
}
