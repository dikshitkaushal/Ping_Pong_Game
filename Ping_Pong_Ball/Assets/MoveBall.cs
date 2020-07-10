using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour {

    public Text player1;
    public Text billy;
    float player_score = 0;
    float billy_score = 0;
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
        player_score = 0;
        billy_score = 0;
        this.transform.position = startpos;
        rb.velocity = Vector3.zero;
        Vector3 dir = new Vector3(Random.Range(100, 300), Random.Range(-100, 100), 0).normalized;
        rb.AddForce(dir * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "backwall" )
        {
            player_score++;
           
            blop.Play();
        }
        else if (collision.gameObject.tag == "playerlose")
        {
            billy_score++;
            
            blop.Play();
        }
        else
        {
            blip.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        billy.text = "Billy_Bot : " + billy_score;
        player1.text = "Player : " + player_score;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }
    }
}
