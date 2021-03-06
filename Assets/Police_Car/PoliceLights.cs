﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame { 
    public class PoliceLights : MonoBehaviour {

        public float time = 0.5f; //time between on and off
        public bool active = false;
        private GameManager gameManager;

	    // Use this for initialization
	    void Start () {
            gameManager = GameManager.GetInstance();
            StartCoroutine("Flicker");
	    }
	
	    // Update is called once per frame
	    void Update () {
            if (gameManager.LightsOn)
            {
                active = true;
            }
            else
            {
                active = false;
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
}
