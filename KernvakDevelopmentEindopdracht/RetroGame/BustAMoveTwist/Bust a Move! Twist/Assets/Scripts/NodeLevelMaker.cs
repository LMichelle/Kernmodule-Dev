using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class NodeLevelMaker : MonoBehaviour {

        public GameObject Bubble;
        public GameObject Grid;

        public bool finished = false;
        public bool isThereCollision;
        public bool canHoldNewBall;

        public List<GameObject> bubblesSameColorList;
        public List<GameObject> nearNodesList;
        private List<GameObject> bubblesAroundList;

        public void Start() {
            Grid = GameObject.FindGameObjectWithTag("Grid");

        }

        public void Update() {
            // If scene is loaded, et all pre-set bubbles first so this script gets it's bubble. If there is no bubble > finished checking.
            if (isThereCollision == false) {
                finished = true;
            }

            bubblesAroundList = GetComponentInParent<NodeChecker>().bubblesAroundList;
            nearNodesList = GetComponentInParent<NodeChecker>().nearNodesList;

            if (Bubble != null) {
                GetNearColors(Bubble);
            }
            
        }

        // If there is a bubble, set it to line up with the proper node.
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "BubbleInScene") {
                isThereCollision = true;
                Bubble = collision.gameObject;
                Bubble.transform.position = this.transform.position;
                Bubble.transform.SetParent(this.transform);
                finished = true;
            }

            // If there is a shot bubble, see if this node has surrounding bubbles.
            if (collision.gameObject.tag == "shotBubble") {
                if (bubblesAroundList.Count >= 1) { // if true, then this node may hold a bubble.
                    canHoldNewBall = true;
                }
            }
        }

        // Change a shot Bubble into a grid bubble
        public void ChangeShotBubbleToGridBubble(GameObject changeBub) { 
            Rigidbody2D rb = changeBub.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;   
            changeBub.transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0.0f);
            rb.sharedMaterial = null;
            Destroy(changeBub.GetComponent<BubbleShot>());
            changeBub.AddComponent<BubbleInGrid>();
            changeBub.transform.position = this.transform.position;
            changeBub.tag = "hasBeenShot";
            changeBub.transform.SetParent(this.transform);
            Bubble = changeBub;
            GetNearColors(Bubble);
            DestroyBubble();
        } 

        public void GetNearColors(GameObject changeBub) {
            if (!bubblesSameColorList.Contains(changeBub)) {
                bubblesSameColorList.Add(changeBub);
            }          
             
            foreach (GameObject bubble in bubblesAroundList) {
                if (!bubblesSameColorList.Contains(bubble)) {
                    BubbleColor colorScript = bubble.GetComponent<BubbleColor>();
                    if (colorScript.rColors == changeBub.GetComponent<BubbleColor>().rColors) {
                        bubblesSameColorList.Add(bubble);
                    }
                }                    
            }          
        }

        public void DestroyBubble() {
            if (bubblesSameColorList.Count >= 2) {
                foreach (GameObject bubble in bubblesSameColorList) {
                    Grid.GetComponent<Grid>().points += 10;
                    Destroy(bubble);
                }
            }
        }
    }
}
