using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    private GameObject _objectToRotate;

    private void Start()
    {
        _objectToRotate = FindObjectOfType<KartRaceInfo>().gameObject;
    }

    private void Update()
    {
        _objectToRotate.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
