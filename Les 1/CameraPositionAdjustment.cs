using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionAdjustment : MonoBehaviour {
    // Public variables
    public GameObject Camera;
    public CameraBehaviour cameraScript;

    // UNITY FUNCTIONS -------------------------------------
    void Start () {
        Camera = GameObject.Find("Main Camera");
        cameraScript = Camera.GetComponent<CameraBehaviour>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            cameraScript.setPos(collision.transform, collision.transform);
        }
    }
}




 
