using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class ArrowControl : MonoBehaviour {
        public float speed = 1.0f;
        private float angle = 0.0f;
        public Transform shootPoint;

        public void Update() {
            Move();
        }


        public void Move() {
            angle -= Input.GetAxis("Horizontal") * speed;
            angle = Mathf.RoundToInt(angle);
            angle = Mathf.Clamp(angle, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
