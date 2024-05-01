using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarController : MonoBehaviour
{
    [Header("Timer")]
    private float currentTime;
    [SerializeField]  private float timePerDown;

    [Header("Values")]
    public bool stopDamage;
    [SerializeField] private Image Bar;
    [SerializeField] private Scrollbar HandleValue;
    [SerializeField] private float ConstantDamage;
    [SerializeField] private float OrbDamage;
    [SerializeField] private float PlayerDamage;

    [Header("Tutorial")]
    [SerializeField] private bool Tutorial;

    #region Conditions
    private bool Die;
    private bool Win;
    #endregion
    private void Start() {
        HandleValue = GetComponent<Scrollbar>();
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0 && !Die && !Win){
            ConstantDown();
           currentTime = timePerDown; 
        }else
        {
            if (Bar.fillAmount <= 0)
            {
                SceneData.Instance.Winner();
            }else if (Bar.fillAmount >= 1)
            {
                SceneData.Instance.Loser();
            }
        }
    }
    private void ConstantDown(){
        Bar.fillAmount += ConstantDamage;
        HandleValue.value -= ConstantDamage;
    }

    public void Orb(){
        if (Tutorial){
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            boss.GetComponent<TutoStateMachine>().PassState();
            Bar.fillAmount -= OrbDamage;
            HandleValue.value += OrbDamage;
        }else{
            Bar.fillAmount -= OrbDamage;
            HandleValue.value += OrbDamage;
        }
        
    }

    public void PlayerDamaged(){
        Bar.fillAmount += PlayerDamage;
        HandleValue.value -= PlayerDamage;
    }
}
