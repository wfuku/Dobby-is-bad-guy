using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    private float wheelSpeed;
    public float wheelSpeedCoefficient = 100f;
    private float dobbySpeed;
    GameObject dobby;

	// Use this for initialization
	void Start () {
        this.dobby = GameObject.Find("Dobby");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (dobby.GetComponent<DobbyMove>().check == true)
        {
            Destroy(this.gameObject);
        }

        wheelSpeed = dobby.GetComponent<DobbyMove>().dobbySpeed * wheelSpeedCoefficient;
        transform.Rotate(0, 0, -wheelSpeed);
	}
}
