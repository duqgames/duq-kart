using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Skidmarks : MonoBehaviour
{
    public List<TrailRenderer> tiresTrailRenderers;
    
    private Drifting _drifting;
    private KartController _kartController;

    private void Awake()
    {
        _drifting = GetComponent<Drifting>();
        _kartController = GetComponent<KartController>();
        tiresTrailRenderers = GetComponentsInChildren<TrailRenderer>().ToList();
    }

    private void Start()
    {
        foreach (var trail in tiresTrailRenderers)
        {
            trail.emitting = false;
        }
    }

    private void Update()
    {
        if (_drifting.isDrifting && _kartController.isGrounded)
        {
            foreach (var trail in tiresTrailRenderers)
            {
                trail.emitting = true;
            }
        }
        else
        {
            foreach (var trail in tiresTrailRenderers)
            {
                trail.emitting = false;
            }
        }
    }
}