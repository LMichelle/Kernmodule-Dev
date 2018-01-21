using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideWall : MonoBehaviour {

    public List<GameObject> bubblesInScene = new List<GameObject>();

    private bool once = true;

    public void OnTriggerEnter2D(Collider2D collision) {
        foreach (GameObject bub in GameObject.FindGameObjectsWithTag("BubbleInScene")) {
            if (once) {
                bubblesInScene.Add(bub);
            }
        }

        once = false;

        foreach (GameObject bubble in bubblesInScene) {
            // Turn on bubble
            bubble.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
