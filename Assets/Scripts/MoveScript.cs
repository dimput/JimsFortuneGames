using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    private float posX;
    private float posY;
    private float posZ;

    private bool arahKanan,arahKiri;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerScript.Instance.arahKanan){
            arahKanan=true;
        }
        if(PlayerScript.Instance.arahKiri){
            arahKiri=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
        if(arahKanan){
            posX += speed;
        }
        if(arahKiri){
            posX -= speed;
        }

        transform.position = new Vector3(posX, posY, posZ);
    }
}
