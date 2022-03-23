using UnityEngine;

namespace UI.UIGameplay
{
    public class UIPauseCanvas : MonoBehaviour
    {
        private UIPausePanel _pausePanel;
        private bool _gamePaused;

        private void Awake()
        {
            _pausePanel = GetComponentInChildren<UIPausePanel>();
            _pausePanel.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Pause"))
            {
                if (!_gamePaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            _gamePaused = true;
            _pausePanel.gameObject.SetActive(true);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            _gamePaused = false;
            _pausePanel.gameObject.SetActive(false);
        }
    }
}
