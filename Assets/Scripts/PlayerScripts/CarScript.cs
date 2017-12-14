using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace SpillmanGame {
    public class CarScript : MonoBehaviour {

        public float CurrentHealth;
        public int MaxHealth = 100;

        private Slider healthBar;
        private GameManager manager;
        private GameObject playerController;
        private GameObject[] playerModels;
        private bool withinDoorRange = false;

        void Start()
        {
            healthBar = GameObject.FindWithTag("CarHealthBar").GetComponent<Slider>();

            manager = GameManager.GetInstance();
            playerController = GameObject.FindWithTag("Player");
            playerModels = GameObject.FindGameObjectsWithTag("PlayerModel");
            ConfigurePlayerMode();
            CurrentHealth = MaxHealth;
            healthBar.value = MaxHealth;
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
            ThirdPersonCharacter characterScript = playerController.GetComponent<ThirdPersonCharacter>();
            if (manager.ActiveGameMode == SpillmanGame.GameManager.GameMode.PLAYER)
            {
                this.transform.parent = null;
                playerController.transform.position += playerController.transform.forward * 2.5f;
                playerController.transform.position += playerController.transform.right * -1.5f;
                foreach(GameObject obj in playerModels)
                {
                    obj.SetActive(true);
                }
                
                characterScript.SetMoveSpeed(1f);
            }
            else if(manager.ActiveGameMode == SpillmanGame.GameManager.GameMode.CAR)
            {
                playerController.transform.forward = -this.transform.forward;
                playerController.transform.position = this.transform.position;
                playerController.transform.position += playerController.transform.forward * -2;
                
                this.transform.parent = playerController.transform;
                foreach (GameObject obj in playerModels)
                {
                    obj.SetActive(false);
                }
                characterScript.SetMoveSpeed(2.5f);
            }
            else if (manager.ActiveGameMode == SpillmanGame.GameManager.GameMode.DEAD)
            {
                characterScript.SetMoveSpeed(0);
            }
        }

        public void HandleDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                healthBar.value = 0;
                TriggerDeath();
            }
            else
            {
                healthBar.value = CurrentHealth / MaxHealth;
            }
        }

        public void TriggerDeath()
        {
            manager.TriggerDeath();
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
