using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class KartController : MonoBehaviour
{
    [SerializeField] private ParticleSystem idleVFX;
    [SerializeField] private ParticleSystem tireSmokeRight;
    [SerializeField] private ParticleSystem tireSmokeLeft;
    
    public float forwardSpeed, resetSpeed;
    public float reverseSpeed;
    public float turnSpeed;
    
    public LayerMask ground;
    public float airDrag;
    public float groundDrag;
    public Rigidbody motorRb;
    public bool userControlled;
    public bool isGrounded;
    public bool isHit;
    public bool drivingForward;
    public bool drivingReverse;
    
    [HideInInspector] public float forwardAmount;
    [HideInInspector] public float turnAmount;
    [HideInInspector] public float reverseAmount;

    private float _motorForce;
    
    private void Start()
    {
        motorRb.transform.parent = null;
        resetSpeed = forwardSpeed;
    }

    private void Update()
    {
        transform.position = motorRb.transform.position;

        SetUserInputs();
        
        if (forwardAmount > 0 && reverseAmount == 0 && !isHit)
            DriveForward();
        else if (reverseAmount > 0 && forwardAmount == 0 && !isHit)
            DriveReverse();
        else if (isHit)
            StartCoroutine(TakeHit());
        else
            DriveNowhere();
            
        TurnRotation();

        GroundCheckAndNormalRotation();

        if (isGrounded)
            motorRb.drag = groundDrag;
        else
            motorRb.drag = airDrag;
    }
    
    private void FixedUpdate()
    {
        if (isGrounded)
        {
            motorRb.AddForce(transform.forward * _motorForce, ForceMode.Acceleration);
        }
        else
        {
            motorRb.AddForce(transform.up * -40f);
        }
    }

    public IEnumerator TakeHit()
    {
        motorRb.velocity = Vector3.zero;
        transform.Rotate(0, 360 * Time.deltaTime, 0);
        yield return new WaitForSeconds(1);
        isHit = false;
    }
    
    public void SetAiInputs(float forwardAmount, float turnAmount, float reverseAmount)
    {
        this.forwardAmount = forwardAmount;
        this.turnAmount = turnAmount;
        this.reverseAmount = reverseAmount;
    }

    private void SetUserInputs()
    {
        if (userControlled)
        {
            forwardAmount = Input.GetAxisRaw("Accelerate");
            turnAmount = Input.GetAxisRaw("Horizontal");
            reverseAmount = Input.GetAxisRaw("Decelerate");
        }
    }
    private void DriveForward()
    {
        _motorForce = forwardAmount *= forwardSpeed;
        drivingForward = true;
        drivingReverse = false;
        
        idleVFX.Stop();
        tireSmokeRight.Play();
        tireSmokeLeft.Play();
    }

    private void DriveReverse()
    {
        turnAmount *= -1;
        _motorForce = reverseAmount *= -reverseSpeed;
        drivingReverse = true;
        drivingForward = false;
        
        idleVFX.Stop();
    }
    
    private void DriveNowhere()
    {
        _motorForce = 0;
        drivingForward = false;
        drivingReverse = false;
        
        idleVFX.Play();
        tireSmokeRight.Stop();
        tireSmokeLeft.Stop();
    }

    private void TurnRotation()
    {
        float newRotation = turnAmount * turnSpeed * Time.deltaTime;
        transform.Rotate(0, newRotation, 0, Space.World);
    }
    
    private void GroundCheckAndNormalRotation()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, ground);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, .1f);
    }
}