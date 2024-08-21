using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLife : MonoBehaviour
{
    private void Start() {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && DataPlayer.Instance.ActualLife < 3){
            
            DataPlayer.Instance.CryptHeal();
            Destroy(gameObject);
        }
    }
}
