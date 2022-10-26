using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelector : MonoBehaviour
{
    public GameObject[] characters;

    public GameObject[] firstClones;

    public GameObject[] secondClones;

    private int selectedCharacter = 0;
    private int iterator;

    void Start()
    {
        for (int i = 0; i < characters.Length; i++) {
            characters[i].SetActive(false);
            firstClones[i].SetActive(false);
            secondClones[i].SetActive(false);
        }

        characters[selectedCharacter].SetActive(true);
        iterator = GameManager.currentLevel >= 3 ? 3 : GameManager.currentLevel;

        if (iterator >= 2) {
            firstClones[selectedCharacter].SetActive(true);
            if (iterator == 3) {
                secondClones[selectedCharacter].SetActive(true);
            }
        }
    }

    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);

        if (iterator >= 2) {
            firstClones[selectedCharacter].SetActive(false);
            firstClones[newCharacter].SetActive(true);

            if (iterator == 3) {
                secondClones[selectedCharacter].SetActive(false);
                secondClones[newCharacter].SetActive(true);
            }
        }
        selectedCharacter = newCharacter;
    }
}
