using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {
    // Public variables
    public Sprite openedDoorSprite;
    public GameObject Spook;
    public GameObject spawnSpot;
    public GameObject Camera;
    public GameObject keyPanel;
    public GameObject gameController;
    public showKeys keysScript;
    public Scene_Manager scene;
    public int keyVersion;
    public bool openDoor = false;

    // Private variables
    private SpriteRenderer rend;

    // UNITY FUNCTIONS -------------------------------------
    void Start () {
        Spook = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
        Camera = GameObject.Find("Main Camera");
        keyPanel = GameObject.Find("Panel_Keys");
        keysScript = keyPanel.GetComponent<showKeys>();
        gameController = GameObject.Find("GameController");
        scene = gameController.GetComponent<Scene_Manager>();
    }

    private void Update() {
        if (Spook == null) {
            Spook = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (keysScript.keys[keyVersion].enabled == true) {
                if (keysScript.keys[3].enabled == true) {
                    Scene sceneCheck = SceneManager.GetActiveScene();
                    if (sceneCheck.name == "Spook1") {
                        scene.LoadByIndex(2);
                    }                   
                }
                rend.sprite = openedDoorSprite;
                Spook.transform.position = spawnSpot.transform.position;
                Camera.transform.position = new Vector3(Spook.transform.position.x, spawnSpot.transform.position.y + 2, -10);
            }
        }
    }
}
