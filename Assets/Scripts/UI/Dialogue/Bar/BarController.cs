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
    [SerializeField] private Image Bar;
    [SerializeField] private Scrollbar HandleValue;
    [SerializeField] private float ConstantDamage;
    [SerializeField] private float OrbDamage;
    [SerializeField] private float PlayerDamage;

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
            Check();
           currentTime = timePerDown; 
        }else
        {
            if (Bar.fillAmount <= 0)
            {
                //Lose
                Die = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }else if (Bar.fillAmount >= 1)
            {
                //Win
                Win = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void ConstantDown(){
        Bar.fillAmount += ConstantDamage;
        HandleValue.value -= ConstantDamage;
    }
    private void Check(){
        if (HandleValue.value == 0)
        {
            Die = true;
        }
    }

    public void Orb(){
        Bar.fillAmount -= OrbDamage;
        HandleValue.value += OrbDamage;
    }

    public void PlayerDamaged(){
        Bar.fillAmount += PlayerDamage;
        HandleValue.value -= PlayerDamage;
    }
}
