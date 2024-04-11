using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] private Transform[] Spawns;

    private Transform PrevSpawn;
    // Start is called before the first frame update
    void OnEnable()
    {
        SpawnOrb();
    }

    private void SpawnOrb(){
        int index = Random.Range(0, Spawns.Length);
        if (PrevSpawn == null)
        {
            transform.position = Spawns[index].position;
            PrevSpawn = Spawns[index];
        }else {
            if (PrevSpawn == Spawns[index])
            {
                transform.position = Spawns[index].position;
            }else{
                transform.position = Spawns[index].position;
            }
        }
        
    }
}
