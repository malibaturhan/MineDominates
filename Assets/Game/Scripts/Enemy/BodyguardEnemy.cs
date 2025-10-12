using UnityEngine;

public class BodyguardEnemy : Enemy
{
    private void Awake()
    {
        
    }
    public void Shooted()
    {
        Debug.Log("I am shooted " +this.gameObject.name);
    }
}
