using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    public Rigidbody rb;
    public float antiRollForce = 5000f;

    void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        // Sol tekerin süspansiyon sıkışmasını ölç
        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;

        // Sağ tekerin süspansiyon sıkışmasını ölç
        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;

        // Farkı hesapla
        float antiRoll = (travelL - travelR) * antiRollForce;

        // Sol teker havada değilse → sağ tarafa kuvvet uygula
        if (groundedL)
            rb.AddForceAtPosition(wheelL.transform.up * -antiRoll, wheelL.transform.position);
        if (groundedR)
            rb.AddForceAtPosition(wheelR.transform.up * antiRoll, wheelR.transform.position);
    }
}
