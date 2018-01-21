using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class BubbleShot : MonoBehaviour {

        public List<GameObject> nearNodesListFromCollidedBall;

        public int speed = 1;

        public bool collided;
        public bool done;

        public GameObject collidedBall;
        private GameObject shootPoint;

        private Rigidbody2D rb;

        public void Awake() {
            shootPoint = GameObject.FindGameObjectWithTag("shootPoint"); 
            rb = GetComponent<Rigidbody2D>();
            transform.rotation = shootPoint.transform.rotation;
        }

        public void ShootBubble() {
            rb.AddForce(transform.up * speed);
        }

        public void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "BubbleInScene" || collision.gameObject.tag == "hasBeenShot") {
                collidedBall = collision.gameObject;
                collided = true;
            }
        }

        public void OnTriggerStay2D(Collider2D collision) {
            if (collision.gameObject.tag == "Node" && collided && !done) {
                // check if place is in nodeslist of the collided ball
                nearNodesListFromCollidedBall = collidedBall.GetComponentInParent<NodeLevelMaker>().nearNodesList;
                NodeLevelMaker thisNodeScript = collision.gameObject.GetComponentInChildren<NodeLevelMaker>();
                if (thisNodeScript.Bubble == null && thisNodeScript.canHoldNewBall && nearNodesListFromCollidedBall.Contains(collision.gameObject)) {
                    collision.gameObject.GetComponentInChildren<NodeLevelMaker>().ChangeShotBubbleToGridBubble(this.gameObject);
                    done = true;
                }
            }
        }

        public void OnBecameInvisible() {
            Destroy(gameObject);
        }
    }
}
