using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

    private Camera cam;
    public Color color1 = Color.white;
    public GameObject gamefield;

    public float range = 5f, moveSpeed = 3f;

    // Use this for initialization
    void Start ()
    {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cam.backgroundColor = color1;
        }
        /* if (Input.GetKeyUp(KeyCode.A))
         {
             gamefield.GetComponent<Renderer>().material.color = Color.green;
         }
         else if (Input.GetKeyUp(KeyCode.S))
         {
             gamefield.GetComponent<Renderer>().material.color = Color.blue;
         }
         else if (Input.GetKeyUp(KeyCode.D))
         {
             gamefield.GetComponent<Renderer>().material.color = Color.black;
         }*/

        /*float h = Input.GetAxis("Horizontal");
        float xPos = h * range;
        gamefield.transform.position = new Vector3(xPos, 0 , -9);*/

        if (Input.GetKey(KeyCode.RightArrow))
            gamefield.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            gamefield.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            gamefield.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            gamefield.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

}

