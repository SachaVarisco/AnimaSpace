using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLifes : MonoBehaviour
{
    public static CanvasLifes Instance;
    private void Awake()
    {
        if (CanvasLifes.Instance == null)
        {
            CanvasLifes.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory")
        {
            Destroy(gameObject);
        }

    }

}
