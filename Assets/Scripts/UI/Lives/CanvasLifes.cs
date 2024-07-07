using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasLifes : MonoBehaviour
{
    public static CanvasLifes Instance;
    private TMP_Text CountPigeonHead;
    private int CountBattle;

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

        CountPigeonHead = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory")
        {
            Destroy(gameObject);
        }

        int index = 1;
        if (SceneManager.GetActiveScene().name == "CrowCrypt" && index < transform.childCount)
        {
            Destroy(transform.GetChild(index).gameObject);
        }

        if (SceneManager.GetActiveScene().name == "CaranchoCrypt" && index == transform.childCount)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        if (DataPlayer.Instance.PigeonCount > 3)
        {
            CountPigeonHead.text = "3";

        }
        else
        {

            if (DataPlayer.Instance.PigeonCount != CountBattle)
            {

                CountBattle = DataPlayer.Instance.PigeonCount;
                CountPigeonHead.text = CountBattle.ToString();

            }
        }

    }

}
