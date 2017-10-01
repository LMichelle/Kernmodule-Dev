using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    // Public variables
    public GameObject SpookCapsule;
    public GameObject Spookje;
    public isGrounded moveScript;
    public Slider flyBar;
    public float speed; 
    public float verticalMoveTime;
    public float setVerticalMoveTime;  
    public float verticalMove;
    public bool isKeyPressed;
    public bool facingLeft = true;
    
    // Private Variables
    private Rigidbody2D rb;
    
    // UNITY FUNCTIONS ----------------------------------------------------------------
    public void Start () {
        SpookCapsule = GameObject.FindGameObjectWithTag("Player");
        Spookje = GameObject.Find("Spook");
        rb = SpookCapsule.GetComponent<Rigidbody2D>();
        moveScript = SpookCapsule.GetComponent<isGrounded>();
        verticalMoveTime = setVerticalMoveTime;
        flyBar.maxValue = setVerticalMoveTime;
	}

    private void Update() {
        if (SpookCapsule == null) {
            SpookCapsule = GameObject.FindGameObjectWithTag("Player");
            rb = SpookCapsule.GetComponent<Rigidbody2D>();
            moveScript = SpookCapsule.GetComponent<isGrounded>();
            facingLeft = true;
        }
        if (Spookje == null) {
            Spookje = GameObject.Find("Spook");
        }
        flyBar.value = verticalMoveTime;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
            isKeyPressed = true;
        } else {
            isKeyPressed = false;
        }
    }

    private void FixedUpdate () {
        Movement();     
	}


    // OWN FUNCTIONS ------------------------------------------------------------------
    public void Flip() {
        facingLeft = !facingLeft;
        Vector2 scale = Spookje.transform.localScale;
        scale.x *= -1;
        Spookje.transform.localScale = scale;
    }

    void  Movement() {        
        if (moveScript.canMoveVertical == true && verticalMoveTime > 0.0f) {
            if (moveScript.isGroundedBool == false && isKeyPressed == true) {
                verticalMoveTime -= Time.deltaTime;
            }
            if (isKeyPressed == false && verticalMoveTime < setVerticalMoveTime) {
                verticalMoveTime += Time.deltaTime * 0.6f;
            }
            verticalMove = Input.GetAxis("Vertical");
        } else {
            if (moveScript.isGroundedBool == true ) {
                if (verticalMoveTime < setVerticalMoveTime) {
                    verticalMoveTime += Time.deltaTime;
                }    
            }
            verticalMove = 0.0f;            
        }
        
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, verticalMove*speed*0.5f);

        if (move > 0 && facingLeft) {
            Flip();
        }
        else if (move < 0 && !facingLeft) {
            Flip();
        }
    }
}
