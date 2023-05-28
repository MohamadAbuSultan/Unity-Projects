using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PlayerLife : MonoBehaviour
    {

        private Animator animator;
        public AudioSource deathSoundEffect;
        private Rigidbody2D rb;
        private BoxCollider2D boxCollider;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("trap"))
            {
                Die();
            }
        }

        private void Die()
        {
            deathSoundEffect.Play();
            animator.SetTrigger("death");
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    
    }
}