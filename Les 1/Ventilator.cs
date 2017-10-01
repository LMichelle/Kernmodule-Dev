using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : MonoBehaviour {
    // Public variables
    public Animator ventAnimator;
    public Animation anim;
    public ParticleSystem windjes;
    public float ventingTime;
    public float setMaxVentingTime;
    public float stillTime;
    public float maxStillTime;
    

    // UNITY FUNCTIONS -------------------------------------
    void Start () {
        ventAnimator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        ventAnimator.SetBool("Move", true);
	}
	
	void Update () {
        ventingTime -= Time.deltaTime;
        if (ventingTime <= 0.0f) {
            stillTime -= Time.deltaTime;
            if (stillTime >= 0.0f) {
                stopMoving();
            } else {
                ventingTime = setMaxVentingTime;
                stillTime = maxStillTime;
                startMoving();
            }   
        } 
	}

    // OTHER FUNCTIONS -------------------------------------
    void startMoving() {
        ventAnimator.SetBool("Move", true);
        anim.Play();
        windjes.Play();
    }

    void stopMoving() {
        ventAnimator.SetBool("Move", false);
        anim.Stop();
        windjes.Stop();
    }
}
