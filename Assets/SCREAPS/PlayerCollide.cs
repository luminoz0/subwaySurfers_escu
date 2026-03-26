using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField]
    private string obstacleTag = "Obstacle";

    [SerializeField]
    private UnityEvent <Transform> onObstacleCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            onObstacleCollision?.Invoke(transform);
        }
    }
}