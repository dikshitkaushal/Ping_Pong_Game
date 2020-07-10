using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tytyt : MonoBehaviour
{
    Vector3 startpos;
    Rigidbody2D rb;
    float force = 400f;
    public AudioSource blip;
    public AudioSource blop;

    // Start is called before the first frame update
    void Start()
    {
        startpos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Reset();
    }
    public void Reset()
    {
        this.transform.position = startpos;
        rb.velocity = Vector3.zero;
        Vector3 dir = new Vector3(Random.Range(100,200), Random.Range(-100, 100), 0).normalized;
        rb.AddForce(dir * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "backwall")
        {
            blop.Play();
            Reset();
        }
        else
        {
            blip.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
