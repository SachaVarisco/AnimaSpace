using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [Header("Timer")]
    private float currentTime;
    [SerializeField]  private float timePerDown = 1f;

    [Header("Childs")]
    private Transform PJ_Bar;
    private Transform Boss_Bar;
    private Transform Mid_Bar;

    [Header("Scales")]
    private float PJ_Scale = 2;
    private float Boss_Scale = 2;
    private float MidBar_Pos = 0.2f;
    private void Start() {
        currentTime = timePerDown; 
        PJ_Bar =  transform.GetChild(3).gameObject.transform;
        Boss_Bar =  transform.GetChild(2).gameObject.transform;
        Mid_Bar =  transform.GetChild(4).gameObject.transform;
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            ConstantDown();
           currentTime = timePerDown; 
        }
    }
    private void ConstantDown(){
        PJ_Scale -= 0.1f;
        Boss_Scale += 0.1f;
        MidBar_Pos -= 0.33f;
        PJ_Bar.transform.localScale = new Vector2 (PJ_Scale, 2);
        Boss_Bar.transform.localScale = new Vector2 (Boss_Scale, 2);
        Mid_Bar.position = new Vector2(MidBar_Pos ,-4);
    }
}
