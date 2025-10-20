using UnityEngine;

public static class EnemyUtils
{
    public static bool CheckPlayerDistance(Transform playerTransform,
                                           Transform enemyTransform,
                                           float distance)
    {
        float currentDistance = Vector3.Magnitude(playerTransform.position - enemyTransform.position);
        //Debug.Log("current Distance " + currentDistance);
        return currentDistance < distance;
    } 
}
