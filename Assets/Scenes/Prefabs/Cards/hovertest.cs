using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hovertest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingOrder = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(CardInfo.textstatus == "off")
        {
            Destroy(gameObject);
        }
	}
}
