using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BustAMove {
    public class ScoreSingleton : MonoBehaviour {
        private static ScoreSingleton _instance = null;
        public Text scoreText;
        public GameObject grid;
        public int score;

        public static ScoreSingleton Instance {
            get {
                return _instance;
            }
        }

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this.gameObject);
            }
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update() {
            if (scoreText == null) {
                scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            }
            if( grid == null) {
                grid = GameObject.FindGameObjectWithTag("Grid");
                
            }
            if (grid != null) {
                score = grid.GetComponent<Grid>().points;
            }

            if (scoreText != null) {
                scoreText.text = "Score Jippie! " + score.ToString();
            }
        }


    }
}
