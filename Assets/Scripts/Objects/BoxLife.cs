using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLife : MonoBehaviour
{
    private void Start() {
        
    }
    public void Heal() {
        if(DataPlayer.Instance.ActualLife < 3){
            
            DataPlayer.Instance.CryptHeal();
            Destroy(gameObject);
        }
    }
}
