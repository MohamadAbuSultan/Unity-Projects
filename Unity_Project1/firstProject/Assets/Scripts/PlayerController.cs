using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 0.03f;
    
    [SerializeField]
    float jump = 10f;

    Transform myTransform;
    SpriteRenderer mySprite;

    public Rigidbody2D rb;

    Animator animator;


    bool isJump;

    public int playerHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        //int myVar = 5;
        //print(myVar);
        //float myFloat = 5.5f;
        //print(myFloat);
        //string myString = "Hello World";
        //print(myString);
        myTransform = GetComponent<Transform>();
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = Color.red;
        //transform.gameObject.SetActive(false);

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-1 * speed, 0)); // new Vector3(-0.03f,0,0) , (-0.03f,0,0)
        //    mySprite.flipX = true;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(speed, 0));
        //    mySprite.flipX = false;
        //}
        // rb.velocity = new Vector2(speed, rb.velocity.y);
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //    mySprite.flipX = true;
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //    mySprite.flipX = false;
        if (Input.GetAxis("Horizontal") > 0)
            mySprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            mySprite.flipX = true;

        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.velocity = new Vector2(0, jump);
            isJump = true;
        }

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
            isJump = false;

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
        // Debug.Log(Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) // لتدمير النسر
    {
        if (collision.CompareTag("Enemy"))
        {
            if(isJump && rb.velocity.y < 0)
                Destroy(collision.gameObject);
            else
                playerHealth--;
        }
        Debug.Log(playerHealth);

        if (playerHealth < 0)
            Debug.Log("You Are Died");
    }

    private void OnCollisionEnter2D(Collision2D collision) // لتدمير الفأر
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isJump && rb.velocity.y < 0)
                Destroy(collision.gameObject);
            else
                playerHealth--;
        }
    }
}
