using System;
using UnityEngine;

namespace AbilitySystem
{
    public class PoopAbility : AbilityBase
    {
        [SerializeField] private GameObject poopPrefab;
        [SerializeField] private Transform dropPosition;
        public override void Activate()
        {
            base.Activate();
            var poop = Instantiate(poopPrefab, dropPosition.position, Quaternion.identity);
            StartCoroutine(CanUseFalse());
            GetComponent<AbilityChecker>().hasAbility = false;
        }
    }
}