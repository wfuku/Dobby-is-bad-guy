using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobbyMove : MonoBehaviour {

    public float dobbySpeed = 0;
    public float dobbySpeedMax;
    public bool run = false;
    public bool check = false;
    public bool checkLock = false;
    public bool areaOut = false;
    public bool runflag = false;
    public float max_x = 83f, max_y = -50f;
    private float now_x; 
    public AudioSource brakingSe;
    public AudioSource carIdling;
    public AudioSource strikingSe;
    public AudioSource carBoonSe;
    public Rigidbody2D rb2;
    Animator animator;
	// Use this for initialization
	void Start () {
        rb2 = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        brakingSe = audioSources[0];
        carIdling = audioSources[1];
        strikingSe = audioSources[2];
        carBoonSe = audioSources[3];

	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (run == true)
        {

            if (dobbySpeed <= dobbySpeedMax)
            {
                dobbySpeed += 0.01f;
            }
        }
    }

	void Update () {

        if (areaOut == true) {
            this.transform.Rotate(0, 0, -40);
        }

        

            if (Input.GetMouseButtonDown(0) && check == false || run == true && transform.position.x >= max_x ){

           
            run = !run;
        }

        if (run == true)
        {
            if (runflag == false)
            {
                carBoonSe.PlayOneShot(carBoonSe.clip);
                runflag = true;
            }
            this.carIdling.Stop();
            this.animator.speed = dobbySpeed * 1.2f;

            animator.SetBool("run", true);

            checkLock = true;

        }
        else if (checkLock == true) {

            if (check == false) {
                strikingSe.PlayOneShot(strikingSe.clip);
                carBoonSe.Stop();
                if (dobbySpeed >= 1)brakingSe.PlayOneShot(brakingSe.clip);
            }

            check = true;
            dobbySpeed *= 0.97f;
            animator.SetBool("check", true);
            animator.speed = 1f;


            if (dobbySpeed <= 0.01f){
                dobbySpeed = 0;
            }

        }

        transform.Translate(Vector2.right*dobbySpeed,Space.World);

        if (transform.position.y <= max_y) {

            rb2.velocity = Vector2.zero;
            rb2.isKinematic = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        areaOut = true;
    }
}
