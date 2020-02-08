using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gomain : MonoBehaviour {
    public AudioSource buttonSe;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        this.buttonSe = GetComponent<AudioSource>();
    }

    public void MainScene() {
        buttonSe.PlayOneShot(buttonSe.clip);
        SceneManager.LoadScene("main");
    }
}
