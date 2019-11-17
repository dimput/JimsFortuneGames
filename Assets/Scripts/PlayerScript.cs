﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public static PlayerScript Instance;

    private float posX;
    private float posY;
    private float rotate=0;
    private bool arahKiri,arahKanan=true;
    private float posZ;
    private int countJump=0;
    public float speed;
    // Start is called before the first frame update
    private Rigidbody2D playerRb;
    Animator charAnimator;
    void Start()
    {
        Instance = this;
        charAnimator = GetComponent<Animator>(); 
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        countJump=0;
    }
    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        print("rotate : " + rotate);

        posZ = transform.position.z;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(arahKiri){
                transform.Rotate(0,180,0);
                arahKanan = true;
                arahKiri = false;
            }
            posX += speed;
            transform.position = new Vector3(posX, posY, posZ);
            charAnimator.SetBool("isWalk",true);
            rotate = 0;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(arahKanan){
                transform.Rotate(0,180,0);
                arahKiri = true;
                arahKanan = false;
            }
            posX -= speed;
            charAnimator.SetBool("isWalk",true);
            transform.position = new Vector3(posX, posY, posZ);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)) && (countJump<1))
        {
            playerRb.AddForce(new Vector3(0f,1f,0f)*10,ForceMode2D.Impulse);
            countJump+=1;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            charAnimator.SetBool("isWalk",false);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            charAnimator.SetBool("isWalk",false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.tag == "Monster"){
            // print ("kena");
            GlobalScript.Instance.health -= 50;
        }        
    }
}
