using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
using EasyTransition;
public class BarController : MonoBehaviour
{
    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float timePerDown;

    [Header("Values")]
    public bool stopDamage;
    [SerializeField] private Image Bar;
    [SerializeField] private Scrollbar HandleValue;
    [SerializeField] private float ConstantDamage;
    [SerializeField] private float OrbDamage;
    [SerializeField] private float PlayerDamage;

    [Header("Tutorial")]
    [SerializeField] private bool Tutorial;
    private bool endBattle;


    [Header("Transitions")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float loadDelay;
    private void Start()
    {
        HandleValue = GetComponent<Scrollbar>();
        endBattle = false;
    }

    void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && !endBattle)
        {
            ConstantDown();
            currentTime = timePerDown;
        }
        else if (!endBattle) 
        {
            if (Bar.fillAmount <= 0 && SceneManager.GetActiveScene().name == "Carmin")
            {
                endBattle = true;
                // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
                // {
                //     { "orbCount", DataPlayer.Instance.orbCount},
                //     { "enemyName", "Ant" },
                //     { "enemyCount", 1f}
                // };

                // AnalyticsService.Instance.RecordEvent(EnemyBeat);
                // AnalyticsService.Instance.Flush();

                //SceneData.Instance.Winner();
                StartCoroutine("DeadAnimAnt");

            }

            if (Bar.fillAmount <= 0 && SceneManager.GetActiveScene().name == "Carancho")
            {
                endBattle = true;
                // CustomEvent EnemyBeat = new CustomEvent("EnemyBeat")
                // {
                //     { "orbCount", DataPlayer.Instance.orbCount},
                //     { "enemyName", "Carancho" },
                //     { "enemyCount", 6f}
                // };

                // AnalyticsService.Instance.RecordEvent(EnemyBeat);
                // AnalyticsService.Instance.Flush();

                //SceneManager.LoadScene("Victory");
                StartCoroutine("DeadAnimCarancho");
                

            }
            else if (Bar.fillAmount >= 1)
            {
                endBattle = true;
                SceneData.Instance.Loser();
            }
        }
    }
    private void ConstantDown()
    {
        Bar.fillAmount += ConstantDamage;
        HandleValue.value -= ConstantDamage;
    }

    public void Orb()
    {
        if (Tutorial)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            boss.GetComponent<TutoStateMachine>().PassState();
            Bar.fillAmount -= OrbDamage;
            HandleValue.value += OrbDamage;
        }
        else
        {
            Bar.fillAmount -= OrbDamage;
            HandleValue.value += OrbDamage;
        }

    }

    public void PlayerDamaged()
    {
        Bar.fillAmount += PlayerDamage;
        HandleValue.value -= PlayerDamage;
    }


    #region DeadAnim Ant
    private IEnumerator DeadAnimAnt(){
        Animator bossAnim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        bossAnim.Play("Dead_AntBoss");
        yield return new WaitForSeconds(1f);
        SceneData.Instance.Winner();
    }
    #endregion

    #region DeadAnim Ant
    private IEnumerator DeadAnimCarancho(){
        Animator bossAnim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        bossAnim.Play("Dead_CaranchoBoss");
        yield return new WaitForSeconds(1f);
        TransitionManager.Instance().Transition("Lotor", transition, loadDelay);
        Debug.Log("EnemyBeat evento");
    }
    #endregion
}
