using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    AudioSource buttonSe;

    void Start()
    {
        this.buttonSe = GetComponent<AudioSource>();
    }

    public void GoTitle(){
        buttonSe.PlayOneShot(buttonSe.clip);
        SceneManager.LoadScene("Title");
    }

}
