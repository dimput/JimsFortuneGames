using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    private float posX;
    private float posY;
    private float rotate = 0;
    private bool arahKiri, arahKanan = true, death = false;
    private float posZ;
    private int countJump = 0;
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

    private void OnCollisionStay2D(Collision2D other)
    {
        countJump = 0;
    }
    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        print("rotate : " + rotate);

        posZ = transform.position.z;
        if (!GlobalScript.Instance.gameOver)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (arahKiri)
                {
                    transform.Rotate(0, 180, 0);
                    arahKanan = true;
                    arahKiri = false;
                }
                posX += speed;
                transform.position = new Vector3(posX, posY, posZ);
                charAnimator.SetBool("isWalk", true);
                rotate = 0;

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (arahKanan)
                {
                    transform.Rotate(0, 180, 0);
                    arahKiri = true;
                    arahKanan = false;
                }
                posX -= speed;
                charAnimator.SetBool("isWalk", true);
                transform.position = new Vector3(posX, posY, posZ);
            }
            if ((Input.GetKeyDown(KeyCode.UpArrow)) && (countJump < 1))
            {
                playerRb.AddForce(new Vector3(0f, 1f, 0f) * 10, ForceMode2D.Impulse);
                charAnimator.SetBool("isJump", true);
                countJump += 1;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                charAnimator.SetBool("isWalk", false);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                charAnimator.SetBool("isWalk", false);
            }
        }
        if (GlobalScript.Instance.health <= 0)
        {
            death = true;
        }
        if (death)
        {
            transform.localPosition = new Vector3(2.41f, -0.81f, 73);
            CameraController.Instance.setLocationCamera();
            if (GlobalScript.Instance.life > 1)
            {
                GlobalScript.Instance.health = 100;
                GlobalScript.Instance.life -= 1;
                death = false;
            }
            else
            {
                GlobalScript.Instance.gameOver = true;
                charAnimator.SetBool("isWalk", false);
                GlobalScript.Instance.panelGameOver.SetActive(true);
                GlobalScript.Instance.panelScore.SetActive(false);
            }
        }
    }

    public bool isDeath()
    {
        return death;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            // print ("kena");
            GlobalScript.Instance.health -= 50;
        }
        if (other.gameObject.tag == "DeathZone")
        {
            // print ("kena");
            death=true;
        }
    }
}
