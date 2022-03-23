using System;
using Customization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SavingLoading
{
    public class SaveKart : MonoBehaviour
    {
        private Button _saveButton;

        private void Awake()
        {
            if (GetComponent<Button>() != null)
                _saveButton = GetComponent<Button>();
        }

        private void Start()
        {
            _saveButton.onClick.AddListener(SaveCustomKart);
        }

        private void SaveCustomKart()
        {
            //PrefabUtility.SaveAsPrefabAsset(CharacterSelectionManager.Instance.duckKart,
            //    "Assets/Resources/Karts/DuckKartCustomized.prefab");
        }
    }
}