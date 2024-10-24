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
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);

        }


        if (SceneManager.GetActiveScene().name == "Puzzle2")
        {
            transform.GetChild(1).gameObject.SetActive(false);
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
