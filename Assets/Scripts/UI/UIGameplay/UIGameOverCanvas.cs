using System;
using UnityEngine;

namespace UI.UIGameplay
{
    public class UIGameOverCanvas : MonoBehaviour
    {
        [HideInInspector] public UIFinalResultsText uiFinalResultsText;

        private void Awake()
        {
            uiFinalResultsText = GetComponentInChildren<UIFinalResultsText>();
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
