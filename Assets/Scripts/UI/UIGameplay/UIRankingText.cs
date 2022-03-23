using TMPro;
using UnityEngine;

namespace UI.UIGameplay
{
    public class UIRankingText : MonoBehaviour
    {
        private TMP_Text _rankingText;
        private KartRaceInfo _kartRaceInfo;

        private void Start()
        {
            _rankingText = GetComponent<TMP_Text>();
            _kartRaceInfo = PlayerLoaderManager.Instance.playerKart.GetComponent<KartRaceInfo>();
        }

        private void Update()
        {
            if (_kartRaceInfo.isRacing)
            {
                _rankingText.text =
                    $"Pos {RaceManager.Instance.karts.IndexOf(_kartRaceInfo) + 1} / {RaceManager.Instance.karts.Count}";
            }
        }
    }
}
