using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Player;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Reduce Health

            Destroy(gameObject);
        }

    }
}
