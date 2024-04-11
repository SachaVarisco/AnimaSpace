using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueControl : MonoBehaviour
{
    [Header ("UI")]
    private GameObject panel;
    private TextMeshProUGUI dialogueText;
    
    [Header ("Line")]
    private int lineIndex;
    private float typingTime = 0.05f;
    [SerializeField, TextArea(4,6)] private string[] lines;
       
    [Header ("Dialogue")]
    private GameObject dialogueMark;
    public bool autoDialogue = false;
    private bool dialogueStarted;
    private GameObject player;
    
    [Header ("Audio")]
    //[SerializeField] private AudioClip audio;
    [Header ("Totem")]
    [SerializeField] private bool Totem;

    [Header ("PLayer")]
    private bool playerInRange;
    private GameObject cloud;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
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
        //SceneControl.Instance.PlaySound(audio);
        dialogueStarted = true;
        panel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        player.GetComponent<PlayerWorldControl>().talking = true;
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
            player.GetComponent<PlayerWorldControl>().talking = false;
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
        panel = cloud.transform.GetChild(0).gameObject;
        dialogueText = panel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void ChangeScene(){
        if (Totem){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}

