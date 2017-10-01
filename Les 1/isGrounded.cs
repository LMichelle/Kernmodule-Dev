using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour {
    // Public variables
    public bool canMoveVertical;
    public bool isGroundedBool;

    // UNITY FUNCTIONS -------------------------------------
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Floors") {
            canMoveVertical = true;
            isGroundedBool = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision) {
        isGroundedBool = false;
    }
}
