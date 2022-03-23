using System;
using Unity.VisualScripting;
using UnityEngine;

public class KartRaceInfo : MonoBehaviour
{
    public string racerName;
    public int checkpointIndex;
    public float distanceToNextCheckpoint;
    public int currentRacePosition;
    public int currentLap;
    public bool isRacing;
    public int finalPosition;

    private void Start()
    {
        currentLap = 1;
        checkpointIndex = 0;
        isRacing = true;
    }
}