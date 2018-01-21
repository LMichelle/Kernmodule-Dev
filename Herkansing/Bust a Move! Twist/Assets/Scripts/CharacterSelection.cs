using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Collections;

namespace BustAMove {
    public class CharacterSelection : MonoBehaviour {

        public GameObject[] characterList;

        public int index;

        public void Start() {
            index = PlayerPrefs.GetInt("CharacterSelected");
            characterList = new GameObject[transform.childCount];
           
            for (int i = 0; i < transform.childCount; i++) {
                characterList[i] = transform.GetChild(i).gameObject;
            }

            foreach (GameObject go in characterList) {
                go.SetActive(false);
            }

            if (characterList[index]) {
                characterList[index].SetActive(true);
            }
        }

        public void ButtonLeft() {
            characterList[index].SetActive(false);
            index -= 1;

            if (index < 0) {
                index = characterList.Length - 1;
            }

            characterList[index].SetActive(true);
        }

        public void ButtonRight() { 
            characterList[index].SetActive(false);
            index += 1;

            if (index == characterList.Length) {
                index = 0;
            }

            characterList[index].SetActive(true);
        }

        public void ChangeScene() {
            PlayerPrefs.SetInt("CharacterSelected", index);
            SceneManager.LoadScene("Lv1");
        }
    }
}
