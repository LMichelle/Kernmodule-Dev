using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showKeys : MonoBehaviour {
    // Public variables
    public Image[] keys;
    public int keyCounter;

    // UNITY FUNCTIONS -------------------------------------
    void Start () {
        keys = GetComponentsInChildren<Image>();
        keyCounter = 0;
	}
	
	void Update () {
		switch (keyCounter) {
            case 0:
                allImagesDisabled();
                break;
            case 1:
                keys[1].enabled = true;
                break;
            case 2:
                keys[2].enabled = true;
                break;
            case 3:
                keys[3].enabled = true;
                break;
        }
	}

    // OTHER FUNCTIONS -------------------------------------
    public void allImagesDisabled() {
        for (int i = 1; i < keys.Length; i++) {
            keys[i].enabled = false;
        }
    }
}
