using System;
using System.Collections;
using UI.UIGameplay;
using UnityEngine;

namespace AbilitySystem
{
    public class AbilityBase : MonoBehaviour
    {
        protected bool Input;
        protected bool IsActive;
        protected UIAbilitySlot UIAbilitySlot;
        protected KartController KartController;
        
        public bool canUse;
        
        private void Start()
        {
            UIAbilitySlot = FindObjectOfType<UIAbilitySlot>();
            KartController = GetComponentInParent<KartController>();
        }

        public virtual void Update()
        {
            Input = UnityEngine.Input.GetButtonUp("UseAbility");
            
            if(Input && canUse && KartController.userControlled)
                Activate();
        }

        public virtual void Activate()
        {
            UIAbilitySlot.abilityImage.texture = null;
            //AbilityChecker.hasAbility = false;
        }

        public IEnumerator CanUseTrue()
        {
            canUse = true;
            yield return null;
        }
        
        public IEnumerator CanUseFalse()
        {
            canUse = false;
            yield return null;
        }

        public IEnumerator IsActiveTrue()
        {
            yield return null;
            IsActive = true;
            yield return null;
        }
        
        public IEnumerator IsActiveFalse()
        {
            yield return null;
            IsActive = false;
            yield return null;
        }
    }
}