using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class JumpPlatform : MonoBehaviour
    {
        public float pushForce = 120.0f;
        
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                animator.SetBool("Active", true);
                Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRigidbody.AddForce(new Vector2(0.0f, pushForce), ForceMode2D.Impulse);
            }
        }

        public void SetDisactive()
        {
            animator.SetBool("Active", false);
        }
    }
}