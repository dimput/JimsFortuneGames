using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text score;
    public Text life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<Text>().text = GlobalScript.Instance.score.ToString();
        life.GetComponent<Text>().text = GlobalScript.Instance.life.ToString();
    }
}
