using UnityEngine;
using UnityEngine.UI;

namespace UI.UIGameplay
{
    public class UIResumeButton : MonoBehaviour
    {
        private Button _resumeButton;
        private UIPauseCanvas _pauseCanvas;

        private void Awake()
        {
            _resumeButton = GetComponent<Button>();
            _pauseCanvas = GetComponentInParent<UIPauseCanvas>();
        }

        private void Start()
        {
            _resumeButton.onClick.AddListener(_pauseCanvas.ResumeGame);
        }
    }
}
