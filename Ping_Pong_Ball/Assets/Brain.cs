using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameObject paddle;
    public GameObject ball;
    float paddle_max_speed = 15f;
    float paddle_min_Y = 8.8f;
    float paddle_max_Y = 17.55f;
    float yvel;
    Rigidbody2D brb;
    ANN ann;
    // Start is called before the first frame update
    void Start()
    {
        brb = ball.GetComponent<Rigidbody2D>();
        ann = new ANN(6, 1, 1, 4, 0.12);
    }
    public List<double> Run(double bxp,double byp,double pxp,double pyp,double bvx,double bvy,double pvy,bool train)
    {
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        inputs.Add(bxp);
        inputs.Add(byp);
        inputs.Add(pxp);
        inputs.Add(pyp);
        inputs.Add(bvx);
        inputs.Add(bvy);
        outputs.Add(pvy);
        if(train)
        {
            return (ann.Train(inputs, outputs));
        }
        else
        {
            return (ann.CalcOutput(inputs, outputs));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float posy = Mathf.Clamp(paddle.transform.position.y + (yvel * Time.deltaTime * paddle_max_speed), paddle_min_Y, paddle_max_Y);
        paddle.transform.position = new Vector3(paddle.transform.position.x, posy, paddle.transform.position.z);
        List<double> outputs = new List<double>();
        LayerMask backwalllayermask = 1 << 8;
        RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, brb.velocity, 1000, backwalllayermask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "tops")
            {
                Vector3 reflection = Vector3.Reflect(brb.velocity, hit.normal);
                hit = Physics2D.Raycast(ball.transform.position, reflection, 1000, backwalllayermask);
            }
            if (hit.collider.gameObject.tag == "backwall" && hit.collider!=null)
            {
                float Dy = (hit.point.y - paddle.transform.position.y);
                outputs = Run(ball.transform.position.x, ball.transform.position.y, paddle.transform.position.x, paddle.transform.position.y, brb.velocity.x, brb.velocity.y, Dy, true);
                yvel = (float)outputs[0];
            }
        }
        else
        {
            yvel = 0;
        }
    }
}
