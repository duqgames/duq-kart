using System;
using UI.UIGameplay;
using UnityEngine;

namespace Customization
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        public static CharacterSelectionManager Instance;
        public GameObject duckKart;

        private void Awake()
        {
            if (Instance == null) 
                Instance = this;
            else 
                Destroy(gameObject);
            
        }

        private void Start()
        {
            duckKart = Instantiate(Resources.Load("Karts/DuckKartDefault", typeof(GameObject))) as GameObject;
            duckKart.transform.position = Vector3.zero;
            duckKart.transform.rotation = Quaternion.identity;
        }
    }
}
