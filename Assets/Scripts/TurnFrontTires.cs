using System;
using UnityEngine;

public class TurnFrontTires : MonoBehaviour
{
    public GameObject frontRightTire;
    public GameObject frontLeftTire;

    private KartController _kartController;

    private void Awake() => _kartController = GetComponent<KartController>();

    private void Update()
    {
        var wheelTurnRotation = 0f;
        wheelTurnRotation += _kartController.turnAmount * 45;
        frontRightTire.transform.localRotation = Quaternion.Euler(-90, 0, wheelTurnRotation);
        frontLeftTire.transform.localRotation = Quaternion.Euler(-90, 0, wheelTurnRotation);
    }
}