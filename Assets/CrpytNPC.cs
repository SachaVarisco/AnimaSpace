using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrpytNPC : MonoBehaviour
{
    [SerializeField] private GameObject Lifes;
    
    void Start()
    {
        Lifes.SetActive(true);
        DataPlayer.Instance.floorWild = true;
    }

    void Update()
    {
        
    }
}
