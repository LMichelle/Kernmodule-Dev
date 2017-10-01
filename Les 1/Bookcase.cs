using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : MonoBehaviour {
    // Public variables
    public GameObject keyPanel;
    public TextMesh spookText;
    public float counter;
    public AudioSource audioS;

    // Private variables
    private showKeys keyPanelScript;
    private bool once = true;

    // UNITY FUNCTIONS -------------------------------------
    public void Start() {
        keyPanel = GameObject.Find("Panel_Keys");
        keyPanelScript = keyPanel.GetComponent<showKeys>();
        spookText = TextMesh.FindObjectOfType<TextMesh>();
        audioS = keyPanel.GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (once == true) {
                spookText.text = "Got key!";
                audioS.Play();
                keyPanelScript.keyCounter += 1;
                counter = 2.0f;
                once = false;
            }        
        }
    }

    public void Update() {
        if (spookText == null) {
            spookText = TextMesh.FindObjectOfType<TextMesh>();
        }
        if (counter > -1.0f) {
            setCount();
        }          
    }
    
    // OTHER FUNCTIONS -------------------------------------
    public void setCount() {       
        counter -= Time.deltaTime;
        if (counter <= 0.0f) {
            spookText.text = " ";
        }
    }
}
