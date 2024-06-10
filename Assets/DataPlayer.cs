using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPlayer : MonoBehaviour
{
    public static DataPlayer Instance;

    [Header("Positions")]
    private GameObject Player;
    Vector2 SpawnReturn;
    public bool IsBack = false;

    private void Awake()
    {
        if (DataPlayer.Instance == null)
        {
            DataPlayer.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("scene loaded");
        
        if (scene.name == "Cripta")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    public void SaveWorldPosition()
    {
        Debug.Log("Save");
        SpawnReturn = new Vector2(Player.transform.position.x, Player.transform.position.y);

    }

    public void LoadWorldPosition()
    {
        Debug.Log("Load");
        Player.transform.position = SpawnReturn;
        IsBack = false;
    }
}
