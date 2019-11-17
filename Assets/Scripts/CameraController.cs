using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float offset;
    private float x = 0.6076f;
    public int dimas = 0;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.transform.position.x>2.1f && player.transform.position.x<101f){
            transform.position = new Vector3(player.transform.position.x+offset,transform.position.y,transform.position.z);
        }
    }
    void Update()
    {
        if(dimas == 9){
            transform.position = new Vector3(0,0,0);
        }
    }
}
