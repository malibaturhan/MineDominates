using UnityEngine;

public class BodyguardEnemy : Enemy
{
    

    public void Shooted()
    {
        Debug.Log("I am shooted " +this.gameObject.name);
    }
}
