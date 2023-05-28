using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class StickyPlatform : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }
}