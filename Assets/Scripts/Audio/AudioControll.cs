using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    public static AudioControll Instance;
    public AudioSource audioSource;

    [Header ("Player sounds")]
    [SerializeField] private AudioClip Hurt;
    [SerializeField] private AudioClip Hit;
    [SerializeField] private AudioClip Jump;
    [SerializeField] private AudioClip WalkWorld;
    [SerializeField] private AudioClip WalkCombat;

    [Header ("Boss sounds")]
    [SerializeField] private AudioClip MonsterAttack;
    [SerializeField] private AudioClip MonsterDamaged;

    [Header ("Other sounds")]
    [SerializeField] private AudioClip EndDialogue;
    [SerializeField] private AudioClip Orb;

    private void Awake()
    {
       if (AudioControll.Instance == null)
        {
            AudioControll.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }  else
        {
            Destroy(gameObject);
        } 
        audioSource = GetComponent<AudioSource>();
    }

    public void StopSound(){
        audioSource.Stop();
    }

    public void PlaySound(AudioClip audio){
        audioSource.PlayOneShot(audio);
    }

    /*public void Hurted(){
        audioSource.clip = Hurt;
        //audioSource.volume = 0;
        audioSource.Play();
    }
    public void Attack(){
        audioSource.clip = Hit;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void PlayerJump(){
        audioSource.clip = Jump;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void MonsterAtt(){
        audioSource.clip = MonsterAttack;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void MonsterDam(){
        audioSource.clip = MonsterDamaged;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void GetOrb(){
        audioSource.clip = Orb;
        //audioSource.volume = 0;
        audioSource.Play();
    }
    public void EndDiag(){
        audioSource.clip = EndDialogue;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void Walk(){
        audioSource.clip = WalkWorld;
        audioSource.loop = true;
        //audioSource.volume = 0;
        audioSource.Play();
    }

    public void Walk8bit(){
        audioSource.clip = WalkCombat;
        audioSource.loop = true;
        //audioSource.volume = 0;
        audioSource.Play();
    }*/

}
