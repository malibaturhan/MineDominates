using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer trailRenderer;
    private MeshRenderer meshRenderer;
    [SerializeField] private float bulletSpeed = 10;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        Launch();
    }

    public void Launch()
    {
        rb.linearVelocity += transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit " + collision.gameObject.name);
        trailRenderer.enabled = false;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(10);
        }
        StartCoroutine("DestroyBullet");
    }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.Log("Bullet hit " + collision.gameObject.name);
    //    trailRenderer.enabled = false;
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //        enemy.TakeDamage(10);
    //    }
    //    StartCoroutine("DestroyBullet");
    //}

    IEnumerator DestroyBullet()
    {
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
