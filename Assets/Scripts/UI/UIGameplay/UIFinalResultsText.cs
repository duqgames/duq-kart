using System;
using TMPro;
using UnityEngine;

namespace UI.UIGameplay
{
    public class UIFinalResultsText : MonoBehaviour
    {
        private TMP_Text _finalResultsText;

        private void Awake()
        {
            _finalResultsText = GetComponent<TMP_Text>();
        }

        public void GetFinalResults(KartRaceInfo kartRaceInfo)
        {
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 1)
                _finalResultsText.text = "You placed 1st.\nYou are a quackin GOD.";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 2)
                _finalResultsText.text = "You placed 2nd.\nA valiant effort.\nThe ducks are still proud.";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 3)
                _finalResultsText.text = "You placed 3rd.\nNot Bad.\nDo you have any grapes?";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 4)
                _finalResultsText.text = "You placed 4th.\nNot Great.\nMaybe next time try going faster?";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 5)
                _finalResultsText.text = "You placed 5th.\nNot Good.\nSeriously though, do you have any grapes?";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 6)
                _finalResultsText.text = "You placed 6th.\nYou disappoint us...\nGot any bread?";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 7)
                _finalResultsText.text = "You placed 7th.\nWhat are you doing?\nYou could be giving us grapes.";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 8)
                _finalResultsText.text = "You placed 8th.\nOk maybe you tried.\nBut that was still fowl.";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 9)
                _finalResultsText.text = "You placed 9th.\nYou are bad at this.\nBut about those grapes...";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 10)
                _finalResultsText.text = "You placed 10th.\nFowl performance.\nJust fowl...";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 11)
                _finalResultsText.text = "You placed 11th.\nYou bring dishonor on all ducks.\nDo you have any grapes?";
            if (RaceManager.Instance.karts.IndexOf(kartRaceInfo) + 1 == 11)
                _finalResultsText.text = "You placed 12th.\nMaybe try giving us some grapes?";
        }
    }
}
