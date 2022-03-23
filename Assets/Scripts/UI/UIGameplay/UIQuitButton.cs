using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.UIGameplay
{
    public class UIQuitButton : MonoBehaviour
    {
        private Button _quitButton;

        private void Awake()
        {
            _quitButton = GetComponent<Button>();
        }

        private void Start()
        {
            _quitButton.onClick.AddListener(LoadMainMenu);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }
}
