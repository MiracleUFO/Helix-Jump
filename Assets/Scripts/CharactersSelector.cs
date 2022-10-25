using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;
    void Start()
    {
        foreach(GameObject ch in characters) {
            ch.SetActive(false);
        }
        characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
    }
}
