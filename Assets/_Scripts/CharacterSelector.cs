using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] _characterModels;
    [SerializeField]
    private int selectedCharacter = 0; 

    // Start is called before the first frame update
    void Start()
    {
        foreach (var model in _characterModels)
        {
            model.SetActive(false); 
        }
        _characterModels[selectedCharacter].SetActive(true); 
    }

    public void SelectCharacter(int newCharacter)
    {
        _characterModels[selectedCharacter].SetActive(false);
        _characterModels[newCharacter].SetActive(true); 
        selectedCharacter = newCharacter;
    }
}
