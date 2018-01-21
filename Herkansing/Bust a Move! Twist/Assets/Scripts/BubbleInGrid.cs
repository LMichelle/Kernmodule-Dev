using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class BubbleInGrid : MonoBehaviour {

        //Checks if it has to show
        public void Start() {  
            if (gameObject.tag == "BubbleInScene") {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        public void OnTriggerStay2D(Collider2D collision) {
            if (collision.gameObject.tag == "InsideWall") {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        } 
    }
}
