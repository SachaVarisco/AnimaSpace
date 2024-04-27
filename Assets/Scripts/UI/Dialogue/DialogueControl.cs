using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header ("UI")]
    private GameObject panel;
    private TMP_Text dialogueText;
    private Image faceImageUI;
    private TMP_Text nameText;
    
    [Header ("Line")]
    private int lineIndex;
    private float typingTime = 0.05f;
    [SerializeField, TextArea(4,6)] private string[] lines;
       
    [Header ("Dialogue")]
    private GameObject dialogueMark;
    public bool autoDialogue;
    private bool dialogueStarted;
    private GameObject player;
    [SerializeField] private Sprite face;

    [SerializeField] private string characName;
    
    [Header ("Audio")]
    //[SerializeField] private AudioClip audio;
    [Header ("Combat")]
    [SerializeField] private bool Combat;

    [Header("Tutorial")]
    [SerializeField] private bool Tutorial;
    [SerializeField] private bool EndTutorial;
    [SerializeField] private bool Mark;
    private Animator Boss;


    [Header ("PLayer")]
    private bool playerInRange;
    private GameObject cloud;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Tutorial)
        {
            Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        }
        dialogueMark = gameObject.transform.GetChild(0).gameObject;
        SearchUI();
    }
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (dialogueText.text == lines[lineIndex])
            {
                NextDialogueLine();
            }else
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
            }else if (Input.GetButtonDown("Jump")){
                if (dialogueText.text == lines[lineIndex])
                {
                    NextDialogueLine();
                }else
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
        if (other.gameObject.tag == "Player" )
        {
            playerInRange = false;
            dialogueMark.SetActive(false);
        }
        
    }
    private void StartDialogue(){
        nameText.text = characName;
        faceImageUI.sprite = face;
        //SceneControl.Instance.PlaySound(audio);
        dialogueStarted = true;
        panel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        if(player.name == "WorldPlayer"){
            player.GetComponent<PlayerWorldControl>().talking = true;
        }
        if (player.name == "Player")
        {
            player.GetComponent<CharacterMove>().talking = true;
            Boss.SetBool("Talking", true);
        }
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine(){
        lineIndex++;
        if (lineIndex < lines.Length)
        {
            StartCoroutine(ShowLine());
        }else
        {
            dialogueStarted = false;
            autoDialogue = false;
            panel.SetActive(false);
            dialogueMark.SetActive(true);
            if(player.name == "WorldPlayer"){
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

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach (char ch in lines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void SearchUI(){
        cloud = GameObject.FindGameObjectWithTag("Canva");
        panel = cloud.transform.GetChild(1).gameObject;
        dialogueText = panel.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        nameText = panel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
        faceImageUI = panel.transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    private void ChangeScene(){    
        if (EndTutorial){
            SceneData.Instance.tutorialPassed = true;
            SceneManager.LoadScene("World"); 
        }
        if (Combat)
        {
            SceneManager.LoadScene(characName); 
        }
        if (Mark)
        {
            SceneData.Instance.Key();
        }
    }

    private IEnumerator PassTutorial(){
        yield return new WaitForSeconds(4);
        transform.parent.gameObject.GetComponent<TutoStateMachine>().PassState();
    }
}

