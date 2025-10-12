using UnityEngine;

public class DetectVolume : MonoBehaviour
{
    [SerializeField] private Enemy detectingEnemy;
    private void Awake()
    {
        detectingEnemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Detected something");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name} detected player");
            detectingEnemy.ChangeState(new ChaseState());
        }
    }
}
