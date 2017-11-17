using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class NodeChecker : MonoBehaviour {

        public List<GameObject> bubblesAroundList = new List<GameObject>();
        public List<GameObject> nearNodesList = new List<GameObject>();

        public CircleCollider2D nodeCol;

        public bool isDoneCheckingForBubble;
        private bool hasGotNodes = false;
        private bool once = true;

        public void Update() {
            // If scene is loaded, get all pre-set bubbles first
            isDoneCheckingForBubble = GetComponentInChildren<NodeLevelMaker>().finished;

            if (isDoneCheckingForBubble && hasGotNodes && once) {
                GetBubble();
                once = false;
            }  

            // Then update always to see the newly added bubbles
            GetBubble();
        }

        // Gets all near nodes and puts them in a list
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Node") {               
                nearNodesList.Add(collision.gameObject);
                nodeCol = gameObject.GetComponent<CircleCollider2D>();

                // After the list has been filled, the collider becomes smaller to be more accurate
                nodeCol.radius = 0.5f;
                hasGotNodes = true;              
            }
        }
        
        // Gets bubble and adds to bubbles list if it is in a node that surrounds this one.
        void GetBubble() {
            bubblesAroundList.Clear(); 

            foreach (GameObject node in nearNodesList) {
                GameObject bubble = node.GetComponentInChildren<NodeLevelMaker>().Bubble;          
                     
                if (bubble != null) {                   
                    bubblesAroundList.Add(bubble);
                }
            }               
        }

    }
}
