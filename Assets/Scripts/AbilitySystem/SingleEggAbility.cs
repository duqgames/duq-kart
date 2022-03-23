using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    public class SingleEggAbility : AbilityBase
    {
        [SerializeField] private GameObject eggPrefab;
        [SerializeField] private Transform projectileStart;
        [SerializeField] private float projectileSpeed = 50f;
        
        public override void Activate()
        {
            base.Activate();
            
            StartCoroutine(ShootEgg());
        }

        private IEnumerator ShootEgg()
        {
            var egg = Instantiate(eggPrefab, projectileStart.position, Quaternion.identity);
            
            egg.TryGetComponent<Collider>(out Collider eggCollider);
            egg.TryGetComponent<Rigidbody>(out Rigidbody eggRb);

            eggCollider.enabled = false;
            yield return null;
            
            egg.transform.position = projectileStart.position;
            yield return null;
            
            
            eggRb.constraints = RigidbodyConstraints.None;
            eggRb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(0.1f);

            eggCollider.enabled = false;

            StartCoroutine(CanUseFalse());
            GetComponent<AbilityChecker>().hasAbility = false;
        }
    }
}