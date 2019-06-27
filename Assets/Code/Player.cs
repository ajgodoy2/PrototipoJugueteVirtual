using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform trans;
    public Rigidbody2D body2D;
    public float speedMovementX;
    public float speedMovementY;
    public Animator anim;


    private void Awake()
    {
        body2D = this.GetComponent<Rigidbody2D>();
        trans = this.transform;
        anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            var movimiento = Vector2.zero;
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                movimiento += Vector2.down;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                movimiento += Vector2.up;
            }
            body2D.velocity = speedMovementY * movimiento.normalized;
        }
        {
            var v = body2D.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -speedMovementX;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += speedMovementX;
            }
            v.x = speed;
            body2D.velocity = v;
            { // Rotation around y-axis
                if (speed > 0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (speed < -0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            anim.SetFloat("Speed", Mathf.Abs(speed));

        }
    }
    private void OnCollisionEnter2D(Collision2D colisionar)
    {
        var newObject = colisionar.collider.gameObject;
        if (newObject.tag == "Gem")
        {
            var scala = this.transform.localScale;
            if (scala.y < 0.7f)
            {
                scala.y *= 1.5f;
                this.transform.localScale = scala;
            }
            newObject.SetActive(false);
        }
        else if(newObject.tag == "Bonsai")
        {
            var scala2 = this.transform.localScale;
            if (scala2.y > 0.30f)
            {
                scala2.y /= 1.1f;
                this.transform.localScale = scala2;
            }
        }
    }

}
