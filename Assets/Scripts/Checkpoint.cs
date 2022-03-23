using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartRaceInfo>(out KartRaceInfo kartRaceInfo))
        {
            other.TryGetComponent<KartControllerAI>(out KartControllerAI kartControllerAI);
            
            CheckpointManager.Instance.KartThroughCheckpoint(this, kartRaceInfo, kartControllerAI);
        }
    }
}