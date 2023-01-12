using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform prevCharacter;
    public Transform selectedCharacter;
    private bool JobSelected = false;

    private void Start() {
        foreach (Character c in GameManager.instance.characters) 
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() => {
                Debug.Log(c);
                GameManager.instance.SetCharacter(c);
                if (selectedCharacter != null) {
                    prevCharacter = selectedCharacter;
                } 

                selectedCharacter = option.transform;
            });

        }
    }

    public void setJobSelected (bool ifSelected) {
        JobSelected = ifSelected;
    }

    public bool getJobSelected () {
        return JobSelected;
    }
           
}

