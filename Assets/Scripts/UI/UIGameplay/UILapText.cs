using TMPro;
using UnityEngine;

namespace UI.UIGameplay
{
    public class UILapText : MonoBehaviour
    {
        private TMP_Text _lapText;
        private KartRaceInfo _kartRaceInfo;

        private void Start()
        {
            _lapText = GetComponent<TMP_Text>();
            _kartRaceInfo = PlayerLoaderManager.Instance.playerKart.GetComponent<KartRaceInfo>();
        }
        
        private void Update()
        {
            UpdateLapText();
        }

        private void UpdateLapText()
        {
            if (_kartRaceInfo.isRacing)
                _lapText.text = $"Lap {_kartRaceInfo.currentLap}/{RaceManager.Instance.totalLaps}";
            else
                _lapText.text = "Finished";
        }
    }
}
