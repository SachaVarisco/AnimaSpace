using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int PoolSize;
    public GameObject obj;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private List<GameObject> PrefabList;

    [Header("Spawns")]
    [SerializeField] private Transform[] Spawns;
    private float NewPrefab;

    private static Pool instance;
    public static Pool Instance {get {return instance;} }

    private void Awake() 
    {
        NewPrefab = 0;
        if (instance == null)
        {
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddPrefabsToPool(PoolSize);
    }

    private void AddPrefabsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            obj = Instantiate(Prefab);
            obj.SetActive(false);
            PrefabList.Add(obj);
            obj.transform.parent = transform;
        }
    }
    
    public GameObject RequestPrefab()
    {
        for (int i = 0; i < PrefabList.Count; i++)
        {
            if (!PrefabList[i].activeSelf)
            {
                NewPrefab++;
                if (NewPrefab % 2 == 0)
                {
                    PrefabList[i].transform.position = Spawns[0].position;
                }else{
                    PrefabList[i].transform.position = Spawns[1].position;   
                }
                PrefabList[i].SetActive(true);
                return PrefabList[i];
            }
        }
        AddPrefabsToPool(1);
        PrefabList[PrefabList.Count - 1].SetActive(true);
        return PrefabList[PrefabList.Count -1];
    }
   
}
