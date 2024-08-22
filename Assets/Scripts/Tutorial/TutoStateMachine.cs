using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoStateMachine : MonoBehaviour
{
    private int StateCount;
    private Animator Boss;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(StateCount).gameObject.SetActive(true);
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();

    }

    public void BossTrue()
    {

        Boss.SetBool("Talking", true);
    }

    public void BossFalse()
    {

        Boss.SetBool("Talking", false);
    }

    public void Tutorial()
    {
        Debug.Log("hola");
        StartCoroutine("PassTutorial");
    }

    // Update is called once per frame
    public void PassState()
    {
        //transform.GetChild(StateCount).gameObject.SetActive(false);
        StateCount++;
        if (StateCount == 3)
        {
            GameObject canva = GameObject.FindGameObjectWithTag("Canva");
            GameObject bar = canva.transform.GetChild(0).gameObject;
            bar.SetActive(true);
        }
        transform.GetChild(StateCount).gameObject.SetActive(true);
    }

    private IEnumerator PassTutorial()
    {
        yield return new WaitForSeconds(4);
        PassState();
    }

    public void EndTutorial()
    {

        SceneData.Instance.tutorialPassed = true;

        // //evento tutorial
        // AnalyticsService.Instance.RecordEvent("TutoComplete");
        // AnalyticsService.Instance.Flush();

        Debug.Log("TutoComplete evento");


        SceneManager.LoadScene("World");
    }
}
