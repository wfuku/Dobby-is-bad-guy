using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    GameObject GameDirector;
    float alfa = 0f;
    float red, green, blue;

    // Use this for initialization
    void Start () {

        GameDirector = GameObject.Find("GameDirector");
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

    }
	
	// Update is called once per frame
	void Update () {

        if (GameDirector.GetComponent<GameDirector>().gameOver == true){
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += 0.02f;
        }

    }
}