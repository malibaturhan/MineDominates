using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 centerOfMassOffset = new Vector3(0, -0.5f, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset;
    }
}
