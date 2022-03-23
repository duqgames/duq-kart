using System;
using UnityEngine;

public class RotateTires : MonoBehaviour
{
    public GameObject frontRightTire;
    public GameObject frontLeftTire;
    public GameObject backRightTire;
    public GameObject backLeftTire;

    private KartController _kartController;

    private void Awake() => _kartController = GetComponent<KartController>();

    private void Update()
    {
        if (_kartController.isGrounded && _kartController.motorRb.velocity.magnitude > 0.15f)
        {
            backRightTire.transform.Rotate(0, Time.deltaTime * _kartController.motorRb.velocity.magnitude * 100, 0);
            backLeftTire.transform.Rotate(0, Time.deltaTime * _kartController.motorRb.velocity.magnitude * -100, 0);
            frontRightTire.transform.Rotate(0, Time.deltaTime * _kartController.motorRb.velocity.magnitude * 100, 0);
            frontLeftTire.transform.Rotate(0, Time.deltaTime * _kartController.motorRb.velocity.magnitude * -100, 0);
        }
    }
}