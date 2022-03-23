using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    
    private KartController _kartController;
    private void Awake() => _kartController = GetComponent<KartController>();

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _kartController.isGrounded && _kartController.userControlled)
        {
            _kartController.motorRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}