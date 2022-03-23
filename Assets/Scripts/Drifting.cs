using System;
using UnityEngine;

public class Drifting : MonoBehaviour
{
    public float driftDotProduct;
    public bool isDrifting;
    public float driftTimer;

    private KartController _kartController;
    private void Awake() => _kartController = GetComponent<KartController>();
    
    private void Update()
    {
        driftDotProduct = Vector3.Dot(_kartController.motorRb.velocity, transform.forward);

        if (driftDotProduct is < 33 and > 25 && _kartController.isGrounded)
        {
            driftTimer += Time.deltaTime;
            isDrifting = true;
        }
        else
        {
            driftTimer = 0;
            isDrifting = false;
        }
    }
}