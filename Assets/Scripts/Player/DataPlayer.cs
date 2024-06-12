using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DataPlayer : MonoBehaviour
{
    public static DataPlayer Instance;

    [Header("Positions")]
    private GameObject Player;
    Vector2 SpawnReturn;
    public bool IsBack = false;

    [Header("Life")]
    [SerializeField] private int ActualLife;
    [SerializeField] private int MaxLife;
    public UnityEvent<int> changeLife;


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

        ActualLife = MaxLife;
        changeLife.Invoke(ActualLife);

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

    public void CryptDamage(){
        
        int Life = ActualLife - 1;
        if (Life < 0)
        {
            ActualLife = 0; 
        }else{
            ActualLife = Life;
        }
        changeLife.Invoke(ActualLife);
        if (ActualLife <= 0)
        {
            Debug.Log("Death");
        }
    }

    public void CryptHeal(){
        
        int Life = ActualLife + 1;
        if (Life > MaxLife)
        {
            ActualLife = MaxLife;
        }else{
            ActualLife = Life;
        }
        changeLife.Invoke(ActualLife);

    }
}
