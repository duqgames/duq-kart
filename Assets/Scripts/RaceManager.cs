using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;

    public List<KartRaceInfo> karts;
    public List<string> finalRankings;

    public int totalLaps;
    public bool raceActive;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Start()
    {
        karts = FindObjectsOfType<KartRaceInfo>().ToList();
        
    }

    private void Update()
    {
        SortRanking();
    }

    public void SortRanking()
    {
        karts.Sort(SortByLapThenByCheckpoint);
    }

    private int SortByLapThenByCheckpoint(KartRaceInfo a, KartRaceInfo b)
    {
        if (a.currentLap < b.currentLap)
        {
            return 1;
        }
        else if (a.currentLap > b.currentLap)
        {
            return -1;
        }
        else if (a.currentLap == b.currentLap)
        {
            if (a.checkpointIndex < b.checkpointIndex)
            {
                return 1;
            }
            else if (a.checkpointIndex > b.checkpointIndex)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    private int SortByCheckpoint(KartRaceInfo a, KartRaceInfo b)
    {
        if (a.checkpointIndex < b.checkpointIndex)
            return 1;
        else if (a.checkpointIndex > b.checkpointIndex)
            return -1;
        else
            return 0;
    }
}