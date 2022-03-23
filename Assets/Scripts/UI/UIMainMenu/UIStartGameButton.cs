using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.UIMainMenu
{
    public class UIStartGameButton : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        
        private Button _startGameButton;

        private void Awake()
        {
            _startGameButton = GetComponent<Button>();
        }

        private void Start()
        {
            _startGameButton.onClick.AddListener(LoadGameplay);
        }

        private void LoadGameplay()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
