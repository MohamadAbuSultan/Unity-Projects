using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    bool isRight = true;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(rigidbody2D.velocity.x) <= 0.01f)
        {
            isRight= !isRight;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if(isRight)
        {
            rigidbody2D.velocity = new Vector2(Time.fixedDeltaTime * speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(Time.fixedDeltaTime * speed * -1, rigidbody2D.velocity.y);
        }
    }

}
