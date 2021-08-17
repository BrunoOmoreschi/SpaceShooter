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
        Vector3 topRightPoint = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);

        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(topRightPoint);

        Rect cameraRect = new Rect
        (
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y
        );


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        
        position.x += x * Time.deltaTime * speed;
        position.y += y * Time.deltaTime * speed;

        transform.position = position;

        transform.position = new Vector3
        (
            Mathf.Clamp (transform.position.x, cameraRect.xMin, cameraRect.xMax),
            Mathf.Clamp (transform.position.y, cameraRect.yMin, cameraRect.yMax)
        );

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

        GameControler.instance.UpdateLives();

        Destroy (collision.gameObject);
        Destroy (boom, 0.9f);
        Destroy (gameObject);
    }

}
