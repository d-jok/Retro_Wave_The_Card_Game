using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDelete : MonoBehaviour {

	void Start ()
    {
        //CardOnPosition = false;
        //FindObjectOfType<GameProcess>().CardDelete = false;
    }
	
	void Update ()
    {
        if(FindObjectOfType<GameProcess>().CardDelete == true)
        {
            Destroy(this.gameObject);
        }
    }
}
