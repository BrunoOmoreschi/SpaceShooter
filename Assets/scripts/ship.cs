using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public float speed = 5;
    public GameObject laser;
    public Transform cannon;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        
        position.x += x * Time.deltaTime * speed;
        position.y += y * Time.deltaTime * speed;

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space)) Shot();

    }

    void Shot()
    {
        GameObject shot = Instantiate(laser, cannon.position, cannon.rotation);
        shot.TryGetComponent(out Rigidbody2D rb);
        rb.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
        Destroy(shot, 2);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);

        Destroy (collision.gameObject);
        Destroy (boom, 0.9f);
        Destroy (gameObject);
    }

}
