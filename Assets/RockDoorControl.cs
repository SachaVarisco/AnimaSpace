using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDoorControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            if (SceneData.Instance.key){
                gameObject.SetActive(false);
            }
        }
    }
}