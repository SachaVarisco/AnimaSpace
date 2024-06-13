using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrpytNPC : MonoBehaviour
{
    [SerializeField] private GameObject Lifes;
    [SerializeField] private GameObject CountPigeon;
    
    void Start()
    {
        Lifes.SetActive(true);
        CountPigeon.SetActive(true);
        DataPlayer.Instance.floorWild = true;
    }

    void Update()
    {
        
    }
}
