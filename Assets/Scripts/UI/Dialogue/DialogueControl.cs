using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Analytics;

public class DialogueControl : MonoBehaviour
{
    [Header("UI")]
    private GameObject panel;
    private TMP_Text dialogueText;
    private Image faceImageUI;
    private TMP_Text nameText;

    [Header("Line")]
    private int lineIndex;
    private float typingTime = 0.05f;
    [SerializeField, TextArea(4, 6)] private string[] lines;

    [Header("Dialogue")]
    private GameObject dialogueMark;
    public bool autoDialogue;
    private bool dialogueStarted;
    private GameObject player;
    [SerializeField] private Sprite face;

    [SerializeField] private string characName;

    [Header("Audio")]
    [SerializeField] private AudioClip audioDiag;
    [Header("Combat")]
    [SerializeField] private bool Combat;

    [Header("Tutorial")]
    [SerializeField] private bool Tutorial;
    [SerializeField] private bool EndTutorial;
    [SerializeField] private bool DoubleDiag;
    [SerializeField] private bool Key;
    private Animator Boss;


    [Header("PLayer")]
    private bool playerInRange;
    private GameObject cloud;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Tutorial)
        {
            Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        }
        dialogueMark = gameObject.transform.GetChild(0).gameObject;
        SearchUI();
    }
    private void Update()
    {
        if (playerInRange && Input.GetButtonDown("Fire1"))
        {

            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (dialogueText.text == lines[lineIndex])
            {
                NextDialogueLine();
            }
            else //if (Input.GetButtonDown("Fire2"))
            {
                StopAllCoroutines();
                dialogueText.text = lines[lineIndex];
            }
        }
        if (autoDialogue)
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                if (dialogueText.text == lines[lineIndex])
                {
                    NextDialogueLine();
                }
                else //if (Input.GetButtonDown("Fire2"))
                {
                    StopAllCoroutines();
                    dialogueText.text = lines[lineIndex];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            dialogueMark.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            dialogueMark.SetActive(false);
        }

    }
    private void StartDialogue()
    {
        nameText.text = characName;
        faceImageUI.sprite = face;
        AudioControll.Instance.PlaySound(audioDiag);
        dialogueStarted = true;
        panel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        if (player.name == "WorldPlayer")
        {
            player.GetComponent<PlayerWorldControl>().talking = true;
        }
        if (player.name == "Player")
        {
            player.GetComponent<CharacterMove>().talking = true;
            Boss.SetBool("Talking", true);
        }
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        AudioControll.Instance.PlaySound(audioDiag);
        if (lineIndex < lines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            Debug.Log("Talk evento");
            dialogueStarted = false;
            autoDialogue = false;
            panel.SetActive(false);
            dialogueMark.SetActive(true);
            if (player.name == "WorldPlayer")
            {
                player.GetComponent<PlayerWorldControl>().talking = false;
            }
            if (player.name == "Player")
            {
                player.GetComponent<CharacterMove>().talking = false;
                Boss.SetBool("Talking", false);
            }
            if (Tutorial && !EndTutorial)
            {
                StartCoroutine("PassTutorial");
            }
            ChangeScene();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in lines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void SearchUI()
    {
        cloud = GameObject.FindGameObjectWithTag("Canva");
        panel = cloud.transform.GetChild(2).gameObject;
        dialogueText = panel.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        nameText = panel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
        faceImageUI = panel.transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    private void ChangeScene()
    {
        if (EndTutorial)
        {
            SceneData.Instance.tutorialPassed = true;

            //evento tutorial
            AnalyticsService.Instance.RecordEvent("TutoComplete");
            AnalyticsService.Instance.Flush();

            Debug.Log("TutoComplete evento");


            SceneManager.LoadScene("World");
        }
        if (Combat)
        {
            if (characName == "Carmin")
            {

                Debug.Log("CombatBoss evento");
            }

            if (characName == "BirdCrypt")
            {

                Debug.Log("Crypt evento");
            }

            DataPlayer.Instance.SaveWorldPosition();
            SceneManager.LoadScene(characName);
        }
        if (DoubleDiag || SceneData.Instance.win)
        {
            SceneData.Instance.Key(Key);
        }
    }

    private IEnumerator PassTutorial()
    {
        yield return new WaitForSeconds(4);
        transform.parent.gameObject.GetComponent<TutoStateMachine>().PassState();
    }
}

