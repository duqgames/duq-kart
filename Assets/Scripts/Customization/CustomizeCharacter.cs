using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CustomizeCharacter : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    public int _characterIndex;

    private void Start()
    {
        if (RaceManager.Instance == null)
        {
            foreach (var character in characters)
                character.SetActive(false);
        
            characters[0].SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            NextCharacter();
        if(Input.GetKeyDown(KeyCode.O))
            PreviousCharacter();
    }

    private void NextCharacter()
    {
        var oldCharacter = _characterIndex;
        
        _characterIndex++;
        if (_characterIndex >= characters.Count)
            _characterIndex = 0;
        
        var newCharacter = _characterIndex;
        
        UpdateCharacter(oldCharacter, newCharacter);
    }

    private void PreviousCharacter()
    {
        var oldCharacter = _characterIndex;
        
        _characterIndex--;
        if (_characterIndex < 0)
            _characterIndex = characters.Count - 1;

        var newCharacter = _characterIndex;
        
        UpdateCharacter(oldCharacter, newCharacter);
    }
    
    private void UpdateCharacter(int oldCharacter, int newCharacter)
    {
        characters[oldCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);
    }
}
