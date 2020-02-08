using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunGlass : MonoBehaviour {

    public GameObject dobby;
    public float SunGlassSpeed;
    Rigidbody2D r2d;
    public float dobbySpeed;
    int flag = 0;

    // Use this for initialization
    void Start () {
        dobby = GameObject.Find("Dobby");
        r2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        dobbySpeed = dobby.GetComponent<DobbyMove>().dobbySpeed;

        if (dobby.GetComponent<DobbyMove>().check == true){

            if (dobbySpeed >= 1 && flag == 0){
                flag = 1;

            } else if(flag == 0){

                flag = 2;

            }

        }

        if (flag == 1)
        {
            //if (dobby.GetComponent<DobyMove>().check == true){
                    r2d.constraints = RigidbodyConstraints2D.None;
                    this.gameObject.transform.parent = null;
            //}

            this.transform.Rotate(0, 0, -dobbySpeed * 60f);
            this.transform.Translate((SunGlassSpeed + dobbySpeed) * Vector2.right,Space.World);
        }
	}
}
