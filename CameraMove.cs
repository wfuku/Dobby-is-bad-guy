using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    GameObject target;
    public float offset_x,offset_y;
    public bool areaOut;
    public float maxCamDistance = 0.1f;
    private float camDistance = 0f;
    public bool camCheck;

    private void Awake()
    {
        //FPS制限
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start () {
        this.target = GameObject.Find("Dobby");
        
	}
	
	// Update is called once per frame
	void Update () {

        this.areaOut = this.target.GetComponent<DobbyMove>().areaOut;

        Vector3 targetPos = new Vector3(target.transform.position.x+offset_x,target.transform.position.y,target.transform.position.z);

        if (areaOut == true && camCheck == false)
        {
            camCheck = true;
            maxCamDistance = transform.position.x * 0.1f;
        }

            if (this.areaOut == true && camDistance <= maxCamDistance){

            

            transform.position = new Vector3(116f,1.15f, transform.position.z - camDistance);
            camDistance ++;
        }
        else if(this.areaOut == false)
        {

            transform.position = new Vector3(targetPos.x,
                transform.position.y, transform.position.z);
        }
	}
}
