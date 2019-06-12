using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform trans;
    public Rigidbody2D body2D;

    public float wSpeed;
    public float jSpeed;

    private void Awake()
    {
        trans = this.transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        { 
            var variable = body2D.velocity;
            var Hspeed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Hspeed += -wSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Hspeed += wSpeed;
            }
            variable.x = Hspeed;
            body2D.velocity = variable;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body2D.velocity += jSpeed * Vector2.up;
        }
    }
    private void OnCollisionEnter2D(Collision2D colisionar)
    {
        var newObject = colisionar.collider.gameObject;
        if (newObject.tag == "Gem")
        {
            var scala = this.transform.localScale;
            scala.y *=2.5f ;
            this.transform.localScale = scala;
            newObject.SetActive(false);
        }
        else if(newObject.tag == "Bonsai")
        {
            var scala2 = this.transform.localScale;
            scala2.y /= 1.1f;
            this.transform.localScale = scala2;
        }
    }

}
