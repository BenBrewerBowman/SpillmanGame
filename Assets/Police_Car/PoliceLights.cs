using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour {

    public float time = 0.5f; //time between on and off
    public bool active = false;

	// Use this for initialization
	void Start () {
        StartCoroutine("Flicker");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            active = !active;
            Debug.Log("Lights are :" + active);
        }
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(time);
            if (active)
            {
                GetComponent<Light>().enabled = true;
                yield return new WaitForSeconds(time);
            }
        }

    }
}
