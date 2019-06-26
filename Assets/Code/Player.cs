using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform trans;
    public Rigidbody2D body2D;
    public float speed;

    private void Awake()
    {
        body2D = this.GetComponent<Rigidbody2D>();
        trans = this.transform;
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
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movimiento += Vector2.left;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                movimiento += Vector2.right;
            }
            body2D.velocity = speed * movimiento.normalized;
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
