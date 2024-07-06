using System.Collections;
using UnityEngine;

public class PlataformBirdControl : MonoBehaviour
{
    private int currentPlataformBirdIndex = 0;
    //public bool plataformActive;

    private void OnEnable()
    {
        ResetPlataforms();
        ActivateFirstPlataformBird();
    }

    private void ActivateFirstPlataformBird()
    {
        if (transform.childCount > 0)
        {
            GameObject firstPlataformBird = transform.GetChild(0).gameObject;
            firstPlataformBird.SetActive(true);
            Debug.Log("Activated first platform.");
        }
        else
        {
            Debug.Log("No platforms found to activate.");
        }
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

    public void ResetPlataforms()
    {
        // Desactiva todas las plataformas
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject plataformBird = transform.GetChild(i).gameObject;
            plataformBird.SetActive(false);
        }

        // Reinicia el índice
        currentPlataformBirdIndex = 0;
        Debug.Log("Platforms reset.");
    }
}
