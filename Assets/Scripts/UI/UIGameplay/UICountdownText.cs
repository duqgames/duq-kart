using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.UIGameplay
{
    public class UICountdownText : MonoBehaviour
    {
        public int countdownTime = 3;
        private TMP_Text _countdownDisplay;

        private void Awake() => _countdownDisplay = GetComponent<TMP_Text>();

        private void Start() => StartCoroutine(CountdownToStart());

        private IEnumerator CountdownToStart()
        {
            while (countdownTime > 0)
            {
                _countdownDisplay.text = countdownTime.ToString();

                yield return new WaitForSeconds(1f);

                countdownTime--;
            }

            _countdownDisplay.text = "GO!";
            
            RaceManager.Instance.raceActive = true;

            yield return new WaitForSeconds(0.5f);
            
            gameObject.SetActive(false);
        }
    }
}
