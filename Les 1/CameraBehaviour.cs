using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    // Public variables
    public GameObject Spook;
    public bool followY = false;

    // UNITY FUNCTIONS -------------------------------------
    void Start() {
        Spook = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (Spook == null){
            Spook = GameObject.FindGameObjectWithTag("Player");
        }
        setPos(Spook.transform, transform);
    }

    // OTHER FUNCTIONS -------------------------------------
    public void setPos(Transform xPos, Transform yPos) {
        transform.position = new Vector3(xPos.position.x, yPos.position.y, -10);
    }
}
