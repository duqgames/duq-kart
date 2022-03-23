using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KartController))]
[RequireComponent(typeof(KartRaceInfo))]
public class KartControllerAI : MonoBehaviour
{
    [SerializeField] private float reachedTargetDistance;
    [SerializeField] private float reverseDistance = 20f;
    
    public float steeringSkill = 3;
    
    private Vector3 _targetPos;
    private float _distanceToTarget;
    
    private KartController _kartController;
    private KartRaceInfo _kartRaceInfo;

    private void Awake()
    {
        _kartController = GetComponent<KartController>();
        _kartRaceInfo = GetComponent<KartRaceInfo>();
    }

    private void Start()
    {
        if (_kartController.userControlled)
        {
            enabled = false;
            return;
        }
        
        SetTargetPosition(CheckpointManager.Instance.checkpointList[0].transform.position);
        
    }

    private void Update()
    {
        if(RaceManager.Instance.raceActive)
            SendAIInputsToController();
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        _targetPos = targetPos;
    }

    private void SendAIInputsToController()
    {
        if (_kartController.userControlled) return;
        
        var forwardAmount = 0f;
        var turnAmount = 0f;
        var reverseAmount = 0f;
        
        _distanceToTarget = Vector3.Distance(transform.position, _targetPos);
        if (_distanceToTarget > reachedTargetDistance)
        {
            var dirToMovePos = (_targetPos - transform.position).normalized;
            var dot = Vector3.Dot(transform.forward, dirToMovePos);

            if (dot > 0)
            {
                forwardAmount = 1f;
            }
            else
            {
                reverseDistance = 20f;
                if (_distanceToTarget > reverseDistance)
                    forwardAmount = 1f;
                else
                    reverseAmount = 1f;
            }

            var angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePos, Vector3.up);

            if (angleToDir > 0)
                turnAmount = 1f;
            else
                turnAmount = -1f;
        }
        else
        {
            forwardAmount = 0;
            turnAmount = 0;
            reverseAmount = 0;
        }
        
        _kartController.SetAiInputs(forwardAmount, turnAmount, reverseAmount);
    }
}