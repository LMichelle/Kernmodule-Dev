using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSingleton : MonoBehaviour {
    private static ScoreSingleton _instance;
    public GameObject Grid;
    private Text scoreText;
    private int score;

    public static ScoreSingleton Instance {
        get {
            if(_instance == null) {
                 _instance = GameObject.FindObjectOfType<ScoreSingleton>();
            }
            return _instance;
        }
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void Start() {
        scoreText = gameObject.GetComponent<Text>();
    }

    public void Update() {
        scoreText.text = "Score Jippie" + score.ToString();
    }
}
