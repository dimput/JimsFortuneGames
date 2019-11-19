using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnner : MonoBehaviour
{
    public GameObject objectToSpawn;
    // public static BulletScript Instance;
    float spawnPosX;
    float spawnPosY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(objectToSpawn, this.transform);
            // Set posisi object agar berada di sebelah kanan kamera
            spawnPosY = PlayerScript.Instance.transform.position.y + 3;
            if (PlayerScript.Instance.arahKiri)
            {
                spawnPosX = PlayerScript.Instance.transform.position.x + .4f;
            }
            if (PlayerScript.Instance.arahKanan)
            {
                spawnPosX = PlayerScript.Instance.transform.position.x + 1.6f;
            }
            obj.transform.localPosition = new Vector3(spawnPosX, spawnPosY, 70);
        }
    }
}
