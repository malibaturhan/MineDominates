using UnityEngine;
using UnityEngine.AI;

public class DebugVerifier : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private NavMeshAgent agent; // varsa

    [Header("Options")]
    [SerializeField] private bool showInScene = true;
    [SerializeField] private Color gizmoColor = Color.red;

    private float currentDistance;
    private Vector3 lastPlayerPos, lastEnemyPos;

    private void Awake()
    {
        if (playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (enemyTransform == null)
            enemyTransform = transform;

        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (playerTransform == null || enemyTransform == null)
        {
            Debug.LogWarning("[Verifier] Missing references!");
            return;
        }

        // Mesafeyi hesapla
        currentDistance = Vector3.Distance(playerTransform.position, enemyTransform.position);

        // Pozisyon deðiþti mi?
        bool playerMoved = playerTransform.position != lastPlayerPos;
        bool enemyMoved = enemyTransform.position != lastEnemyPos;

        // Konsola yaz (çok fazla spam olmasýn diye sadece deðiþtiðinde)
        if (playerMoved || enemyMoved)
        {
            string info =
                $"[Verifier] Distance={currentDistance:F2} | " +
                $"Player={playerTransform.position} | Enemy={enemyTransform.position}";

            if (agent != null)
                info += $" | AgentPos={agent.nextPosition}";

            Debug.Log(info);
        }

        lastPlayerPos = playerTransform.position;
        lastEnemyPos = enemyTransform.position;
    }

    private void OnDrawGizmos()
    {
        if (!showInScene || playerTransform == null || enemyTransform == null) return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawLine(playerTransform.position, enemyTransform.position);
        Gizmos.DrawSphere(playerTransform.position, 0.2f);
        Gizmos.DrawSphere(enemyTransform.position, 0.2f);
    }
}
