using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class ArrowControl : MonoBehaviour {

        public GameObject instPoint;
        public GameObject shootPoint;
        public GameObject bubble;
        public GameObject bub;
        public GameObject nextBub;

        public bool canShoot = true;

        public int counter;
        public int maxCount;

        private float speed = 1f;
        private float angle = 0.0f;

        public void Start() {
            NewBubble();
        }

        public void Update() {
            Move();
            Debug.DrawRay(shootPoint.transform.position, transform.up * 7, Color.red);  // can only be seen in scene view to help shoot
            if (Input.GetKeyDown(KeyCode.Space) && canShoot) {
                Shoot();
                canShoot = false;                                                       // you can't shoot in succesion, only if bubble has snapped or gone out of view.
            }

            if (bub != null && bub.tag == "hasBeenShot") {
                bub = null;
            }

            if (bub == null) {
                canShoot = true;
                NewBubble();
            }
        }

        private void Move() {
            angle += Input.GetAxisRaw("Horizontal") * speed;
            angle = Mathf.RoundToInt(angle);
            angle = Mathf.Clamp(angle, -85, 85);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void NewBubble() {
            bub = Instantiate(bubble, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, 0.0f), Quaternion.identity);
            bub.transform.SetParent(gameObject.transform);
        }

        public void Shoot() {
            bub.GetComponent<BubbleShot>().ShootBubble();
            bub.transform.parent = null;           
            counter++;
            if (counter > maxCount) {
                counter = 1;
            }
        }
    }
}
