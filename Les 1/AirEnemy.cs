using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirEnemy : MonoBehaviour {
    // Public variables
    public GameObject Spook;
    public Animator anim;
    public GameObject GOpanel;

    // UNITY FUNCTIONS -------------------------------------
    public void Start() {
        Spook = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        if (anim == null) {
            anim = GetComponentInParent<Animator>();
        }
    }

    public void Update() {
        if (Spook == null) {
            Spook = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        anim.StopPlayback();
        GOpanel.SetActive(true);
        Destroy(Spook);      
    }

    public void OnParticleCollision(GameObject other) { 
        if (other.tag == "Player") {
            GOpanel.SetActive(true);
            Destroy(Spook);
        }
    }
}
