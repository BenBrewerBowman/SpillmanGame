using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame {
    public class CarScript : MonoBehaviour {

        private GameManager manager;
        private GameObject playerController;
        private GameObject[] playerModels;
        private bool withinDoorRange = false;

        void Start()
        {
            manager = GameManager.GetInstance();
            playerController = GameObject.FindWithTag("Player");
            playerModels = GameObject.FindGameObjectsWithTag("PlayerModel");
            ConfigurePlayerMode();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Fire3"))
            {
                if(manager.ActiveGameMode == GameManager.GameMode.CAR || (manager.ActiveGameMode == GameManager.GameMode.PLAYER && withinDoorRange))
                {
                    Debug.Log("Fire3 pressed on car");
                    manager.ToggleGameMode();
                    ConfigurePlayerMode();
                }
            }
        }

        private void ConfigurePlayerMode()
        {
            
            if (manager.ActiveGameMode == SpillmanGame.GameManager.GameMode.PLAYER)
            {
                this.transform.parent = null;
                playerController.transform.position += playerController.transform.forward * 2.5f;
                playerController.transform.position += playerController.transform.right * -1.5f;
                foreach(GameObject obj in playerModels)
                {
                    obj.SetActive(true);
                }
            }
            else
            {
                playerController.transform.forward = -this.transform.forward;
                playerController.transform.position = this.transform.position;
                playerController.transform.position += playerController.transform.forward * -2;
                
                this.transform.parent = playerController.transform;
                foreach (GameObject obj in playerModels)
                {
                    obj.SetActive(false);
                }
            }
        }

        private void OnCollisionEnter(Collision collisionInfo)
        {
            Debug.Log("Collision entered.");
        }

        private void OnCollisionExit(Collision collisionInfo)
        {
            Debug.Log("Collision left.");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger entered.");
            withinDoorRange = true;
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Trigger left.");
            withinDoorRange = false;
        }
    }
 }
