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
    private LivesUI LiveCanva;
    [SerializeField] private int ActualLife;
    [SerializeField] private int MaxLife;
    public UnityEvent<int> changeLife;

    [Header("Crypt")]
    public int PigeonCount;
    public bool Ready;
    public bool floorWild;

    public bool pigeonLost;

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

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("scene loaded");

        if (scene.name == "BirdCrypt" || scene.name == "World")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (SceneManager.GetActiveScene().name == "BirdCrypt")
        {

            LiveCanva = GameObject.FindGameObjectWithTag("CanvaLifes").transform.GetChild(0).gameObject.GetComponent<LivesUI>();
            LiveCanva.ChangeSouls(ActualLife);
            //changeLife.Invoke(ActualLife);

            pigeonLost = true;
        }

    }

    private void Update()
    {
        if (PigeonCount == 3)
        {
            PigeonCount = 0;
            Ready = true;
        }

        if (ActualLife <= 0)
        {
            ActualLife = 1;
            SceneData.Instance.Loser();
        }

        if (floorWild && SceneManager.GetActiveScene().name == "BirdCrypt")
        {
            GameObject floorWild = GameObject.FindGameObjectWithTag("Floor");
            floorWild.layer = 7;
        }

        if (SceneManager.GetActiveScene().name == "Victory")
        {
            Destroy(gameObject);
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

    public void CryptDamage()
    {
        Debug.Log("getHit");
        
        int Life = ActualLife - 1;
        if (Life < 0)
        {
            ActualLife = 0;
        }
        else
        {
            ActualLife = Life;
        }
        LiveCanva.ChangeSouls(ActualLife);
        //changeLife.Invoke(ActualLife);
        if (ActualLife <= 0)
        {
            Debug.Log("Death");
        }
    }

    public void CryptHeal()
    {

        int Life = ActualLife + 1;
        if (Life > MaxLife)
        {
            ActualLife = MaxLife;
        }
        else
        {
            ActualLife = Life;
        }
        LiveCanva.ChangeSouls(ActualLife);
        //changeLife.Invoke(ActualLife);

    }

    public void Reset(){

        ActualLife = MaxLife;
        PigeonCount = 0;
        floorWild = false;        
    }
}
