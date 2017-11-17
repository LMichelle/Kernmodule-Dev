using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BustAMove {
    public class GameController : MonoBehaviour {

        public GameObject grid;
        public GameObject PauseMenu;
        public GameObject WinMenu;

        public float restartDelay = 5f;
        public float restartTimer;

        [SerializeField] private string loadLevel;

        public void Update() {
            
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (PauseMenu.activeSelf == true) {
                    PauseMenu.SetActive(false);
                    UnFreezeScene();
                } else {
                    PauseMenu.SetActive(true);
                    FreezeScene();
                }
            }

            if (grid.GetComponent<Grid>().allBubblesList.Count == 0 && grid.GetComponent<Grid>().gotBubbleCount == true) {
                WinMenu.SetActive(true);
                NewLevel();
            }
        }

        // Reload current level
        public void NewLevel() { 
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay) {
                SceneManager.LoadScene(loadLevel);
            }
        }

        public void FreezeScene() {
            Time.timeScale = 0;
            //AudioListener.volume = 0;
        }

        public void UnFreezeScene() {
            Time.timeScale = 1;
            //AudioListener.volume = 1;
        }
    }
}