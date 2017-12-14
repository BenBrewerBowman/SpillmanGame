using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpillmanGame
{
    public class PlayerScript : MonoBehaviour
    {

        public float CurrentHealth;
        public int MaxHealth = 100;

        private Slider healthBar;
        private GameManager manager;
        public GameObject BulletPrefab;
        public Transform BulletSpawn;

        void Start()
        {
            healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
            manager = GameManager.GetInstance();
            CurrentHealth = MaxHealth;
            healthBar.value = MaxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1") && manager.ActiveGameMode == GameManager.GameMode.PLAYER)
            {
                Fire();
            }
        }

        void Fire()
        {
            
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 8;

            Destroy(bullet, 2.0f);
        }

        public void HandleDamage(float damage)
        {
            CurrentHealth -= damage;
            if(CurrentHealth <= 0)
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
      }
}
