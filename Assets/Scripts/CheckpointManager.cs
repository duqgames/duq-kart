using System;
using System.Collections.Generic;
using UI;
using UI.UIGameplay;
using UnityEngine;
using Random = UnityEngine.Random;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public List<Checkpoint> checkpointList = new List<Checkpoint>();

    private UIGameOverCanvas _uiGameOverCanvas;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);
        
        foreach (Transform checkpoint in transform)
        {
            var cp = checkpoint.GetComponent<Checkpoint>();
            checkpointList.Add(cp);
        }

        _uiGameOverCanvas = FindObjectOfType<UIGameOverCanvas>();
    }

    private void Start()
    {
        _uiGameOverCanvas.gameObject.SetActive(false);
    }

    public void KartThroughCheckpoint(Checkpoint checkpoint, KartRaceInfo kartRaceInfo, KartControllerAI kartControllerAI)
    {
        if (kartRaceInfo.checkpointIndex == checkpointList.IndexOf(checkpoint))
        {
            if (checkpointList.IndexOf(checkpoint) == checkpointList.Count - 1)
            {
                kartRaceInfo.checkpointIndex = 0;
                kartRaceInfo.currentLap++;

                if (kartRaceInfo.currentLap > RaceManager.Instance.totalLaps)
                {
                    kartRaceInfo.isRacing = false;
                    RaceManager.Instance.finalRankings.Add(kartRaceInfo.racerName);
                    
                    if (kartRaceInfo.GetComponent<KartController>().userControlled)
                    {
                        _uiGameOverCanvas.gameObject.SetActive(true);
                        _uiGameOverCanvas.uiFinalResultsText.GetFinalResults(kartRaceInfo);
                    }
                }
            }
            else
            {
                kartRaceInfo.checkpointIndex++;
            }
            
            kartControllerAI.SetTargetPosition(checkpointList[kartRaceInfo.checkpointIndex].transform.position);
        }
    }
}