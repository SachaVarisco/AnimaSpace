using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBird : MonoBehaviour
{
    [SerializeField] private float WaitTime;
    private Rigidbody2D Rb2D;
    [SerializeField] private float VelocityRotation;
    private bool isDropped = false;
    private Vector3 initialPosition; // Posición inicial de la plataforma
    private Quaternion initialRotation; // Rotación inicial de la plataforma

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;

    }

    void Update()
    {
        if (isDropped)
        {
            transform.Rotate(new Vector3(0, 0, -VelocityRotation * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(drop(collision));

            FindObjectOfType<PlataformBirdControl>().NotifyPlataformSteppedOn();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls") || collision.gameObject.layer == LayerMask.NameToLayer("FloorBird"))
        {
            gameObject.SetActive(false);

        }


    }

    private IEnumerator drop(Collision2D collision2D)
    {

        yield return new WaitForSeconds(WaitTime);
        isDropped = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), collision2D.transform.GetComponent<Collider2D>());
        Rb2D.constraints = RigidbodyConstraints2D.None;
        Rb2D.AddForce(new Vector2(0.1f, 0f));
    }

    private void OnDisable()
    {
        // Restaurar la posición y rotación inicial si el objeto se desactiva
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        Rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        isDropped = false;
    }



}
