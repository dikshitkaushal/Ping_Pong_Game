using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float paddle_min_Y = 8.8f;
    float paddle_max_Y = 17.55f;
    float speed = 15f;
    float speeed = 200f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float posy = Mathf.Clamp(transform.position.y +   Time.deltaTime * speed, paddle_min_Y, paddle_max_Y);
            transform.position = new Vector3(transform.position.x, posy, transform.position.z);
            //Mathf.Clamp(transform.position.y, paddle_min_Y, paddle_max_Y);
            //transform.Translate(Vector3.up * Time.deltaTime * speed);
            //transform.position += transform.up * Time.deltaTime * speed;
            //rb.velocity = transform.up * Time.deltaTime * speeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            float posy = Mathf.Clamp(transform.position.y - Time.deltaTime * speed, paddle_min_Y, paddle_max_Y);
            transform.position = new Vector3(transform.position.x, posy, transform.position.z);
            //transform.Translate(Vector3.down * Time.deltaTime * speed);
            //transform.position += (-1) * transform.up * Time.deltaTime * speed;
        }
    }
}
