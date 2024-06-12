using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CryptDoor : MonoBehaviour
{
    [SerializeField] private AudioClip doorSound;
    private AudioSource audioSource;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();

        if (gameObject.name == "Puerta-Cripta2")
        {
            audioSource.PlayOneShot(doorSound);
        }

    }
    void Update()
    {
        if (DataPlayer.Instance.Ready == true)
        {
            DataPlayer.Instance.Ready = false;
            gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
