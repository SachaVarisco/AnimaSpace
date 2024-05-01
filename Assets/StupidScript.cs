using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidScript : MonoBehaviour
{
    void Start()
    {
        SceneData.Instance.OnSceneLoaded();
    }
}
