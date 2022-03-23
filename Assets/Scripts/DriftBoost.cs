using System;
using UnityEngine;

public class DriftBoost : MonoBehaviour
{
    public ParticleSystem boostVFX;
    
    public ParticleSystem backRightTireSparksT1;
    public ParticleSystem backLeftTireSparksT1;
    public ParticleSystem backRightTireSparksT2;
    public ParticleSystem backLeftTireSparksT2;
    public ParticleSystem backRightTireSparksT3;
    public ParticleSystem backLeftTireSparksT3;
    
    public float boostMultiplier = 20;
    public bool canDriftBoost;
    
    private float driftBoostAmount;
    private Drifting _drifting;
    private float _driftTimer;
    private float _resetDriftTimer;

    private float startTurnSpeed;
    private KartController _kartController;

    private void Awake()
    {
        _drifting = GetComponent<Drifting>();
        _kartController = GetComponent<KartController>();
    }

    private void Start()
    {
        _resetDriftTimer = 0;
        startTurnSpeed = _kartController.turnSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            canDriftBoost = true;

        if (_drifting.isDrifting && Input.GetButton("Jump") && _driftTimer < 3)
        {
            _driftTimer += Time.deltaTime;
            driftBoostAmount += Time.deltaTime * boostMultiplier;
            _kartController.turnSpeed = startTurnSpeed / 2f;
            
            if (_drifting.driftTimer > 0 && _drifting.driftTimer < 1)
            {
                backRightTireSparksT1.Play();
                backLeftTireSparksT1.Play();
            }
            else if (_drifting.driftTimer > 1 && _drifting.driftTimer < 2)
            {
                backRightTireSparksT2.Play();
                backLeftTireSparksT2.Play();
                
                backRightTireSparksT1.Stop();
                backLeftTireSparksT1.Stop();
            }
            else if (_drifting.driftTimer > 2 && _drifting.driftTimer < 3)
            {
                backRightTireSparksT3.Play();
                backLeftTireSparksT3.Play();
                
                backRightTireSparksT2.Stop();
                backLeftTireSparksT2.Stop();
            }
        }
        else
        {
            backRightTireSparksT1.Stop();
            backLeftTireSparksT1.Stop();
            backRightTireSparksT2.Stop();
            backLeftTireSparksT2.Stop();
            backRightTireSparksT3.Stop();
            backLeftTireSparksT3.Stop();
        }

        if (_drifting.isDrifting && canDriftBoost && Input.GetButtonUp("Jump") && _kartController.isGrounded)
        {
            boostVFX.Play();
            _drifting.isDrifting = false;
            _driftTimer = 0;
            _kartController.motorRb.AddForce(transform.forward * driftBoostAmount, ForceMode.Impulse);
            driftBoostAmount = 0;
            _kartController.turnSpeed = startTurnSpeed;
            canDriftBoost = false;
        }

    }
}