using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = transform.Find("Bar");
        health = GlobalScript.Instance.health / 100;
        // print("health : " + health);
        bar.localScale = new Vector3(health,1f);
    }
}
