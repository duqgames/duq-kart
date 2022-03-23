using UnityEngine;

public class Poop : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<KartController>(out KartController myCarController))
        {
            myCarController.isHit = true;
            Destroy(gameObject);
        }
    }
    
}