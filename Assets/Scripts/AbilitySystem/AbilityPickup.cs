using System;
using System.Collections;
using System.Collections.Generic;
using UI.UIGameplay;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AbilitySystem
{
    public class AbilityPickup : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 50f;
        [SerializeField] private float pickupRespawnTime = 2f;
        
        public List<Texture> abilityImages = new List<Texture>();
        
        private int _abilityIndex;
        private bool _canPickup = true;
        private UIAbilitySlot _uiAbilitySlot;

        private void Awake()
        {
            _uiAbilitySlot = FindObjectOfType<UIAbilitySlot>();
        }

        private void Update()
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<KartController>() != null && _canPickup)
            {
                _abilityIndex = Random.Range(0, 3);

                var abilityChecker = other.GetComponentInChildren<AbilityChecker>();
                if (abilityChecker.hasAbility == false)
                {
                    switch (_abilityIndex)
                    {
                        case 0:
                            StartCoroutine(other.GetComponentInChildren<SingleEggAbility>().CanUseTrue());
                            _uiAbilitySlot.abilityImage.texture = abilityImages[0];
                            break;
                        case 1:
                            StartCoroutine(other.GetComponentInChildren<PoopAbility>().CanUseTrue());
                            _uiAbilitySlot.abilityImage.texture = abilityImages[1];
                            break;
                        case 2:
                            StartCoroutine(other.GetComponentInChildren<ThreeEggsAbility>().CanUseTrue());
                            _uiAbilitySlot.abilityImage.texture = abilityImages[2];
                            break;
                    }

                    abilityChecker.hasAbility = true;
                }
            
                StartCoroutine(DisableWaitAndEnable());
            }
            
        }

        private IEnumerator DisableWaitAndEnable()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            
            meshRenderer.enabled = false;
            _canPickup = false;
            yield return new WaitForSeconds(pickupRespawnTime);
            meshRenderer.enabled = true;
            _canPickup = true;
        }
    }
}