using Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public class RaceCameraManager : MonoBehaviour
    {
        public static RaceCameraManager Instance;

        [HideInInspector] public CinemachineVirtualCamera cmCam;

        private void Awake()
        {
            if (Instance == null) 
                Instance = this;
            else 
                Destroy(gameObject);

            cmCam = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            cmCam.m_Follow = PlayerLoaderManager.Instance.playerKart.transform;
            cmCam.m_LookAt = PlayerLoaderManager.Instance.playerKart.transform;
        }
    }
}
