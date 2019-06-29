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
    public GUIText text;
    private int count;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;


    private void Awake()
    {
        body2D = this.GetComponent<Rigidbody2D>();
        trans = this.transform;
        anim = this.GetComponent<Animator>();
        count = 0;
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
        {
            if (startBlinking == true)
            {
                spriteBlinkingTotalTimer += Time.deltaTime;
                if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
                {
                    startBlinking = false;
                    spriteBlinkingTotalTimer = 0.0f;
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    return;
                }

                spriteBlinkingTimer += Time.deltaTime;
                if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
                {
                    spriteBlinkingTimer = 0.0f;
                    if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
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
            count++;
            text.text = "Total de Gemas " + count  ;
            if (count == 14)
            {
                text.text = "¡Has ganado recogiste todas las gemas!";
            }
        }
        else if(newObject.tag == "Obstacle")
        {
            var scala2 = this.transform.localScale;
            if (scala2.y > 0.30f)
            {
                scala2.y /= 1.1f;
                this.transform.localScale = scala2;
                startBlinking = true;
            }
        }
    }

}
