using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBird : MonoBehaviour
{
    [SerializeField] private float WaitTime;
    private Rigidbody2D Rb2D;
    [SerializeField] private float VelocityRotation;
    private bool Drop = false;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Drop)
        {
            transform.Rotate(new Vector3(0,0, -VelocityRotation * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(drop(collision));

            FindObjectOfType<PlataformBirdControl>().NotifyPlataformSteppedOn();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Destroy(gameObject);
        }


    }

    private IEnumerator drop(Collision2D collision2D)
    {

        yield return new WaitForSeconds(WaitTime);
        Drop = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), collision2D.transform.GetComponent<Collider2D>());
        Rb2D.constraints = RigidbodyConstraints2D.None;
        Rb2D.AddForce(new Vector2(0.1f, 0f));
    }



}
