using UnityEngine;
using UnityEngine.UI;

namespace UI.UIGameplay
{
    public class UIAbilitySlot : MonoBehaviour
    {
        [HideInInspector] public RawImage abilityImage;

        private void Start()
        {
            abilityImage = GetComponent<RawImage>();
        }
    }
}
