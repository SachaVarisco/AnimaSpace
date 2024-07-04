using System.Collections;
using UnityEngine;

public class PlataformBirdControl : MonoBehaviour
{
    private int currentPlataformBirdIndex = 0;

    private void OnEnable()
    {
        ActivateNextPlataformBird();
    }

    private void ActivateNextPlataformBird()
    {
        if (currentPlataformBirdIndex < transform.childCount)
        {
            GameObject plataformBird = transform.GetChild(currentPlataformBirdIndex).gameObject;
            plataformBird.SetActive(true);
            Debug.Log("Activated platform: " + currentPlataformBirdIndex);
        }
        else
        {
            Debug.Log("No more platforms to activate.");
        }
    }

public void NotifyPlataformSteppedOn()
{
    currentPlataformBirdIndex++;
    Debug.Log("Platform stepped on. Next platform index: " + currentPlataformBirdIndex);
    ActivateNextPlataformBird();
}
}
