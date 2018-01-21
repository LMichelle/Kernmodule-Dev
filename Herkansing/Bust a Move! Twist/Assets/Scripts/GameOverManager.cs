using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class GameOverManager : MonoBehaviour {

        public GameObject GameOverPanel;

        public void OnTriggerEnter2D(Collider2D bubbles) {
            if (bubbles.CompareTag("BubbleInScene") || bubbles.CompareTag("hasBeenShot")) {
                GameOverPanel.SetActive(true);
            }
        }
    }
}