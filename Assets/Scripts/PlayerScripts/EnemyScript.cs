using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame
{
    public class EnemyScript : MonoBehaviour, Damageable {

        public GameObject ExplosionPrefab;
        public float MaxHealth = 100.0f;
        private float currentHealth;

	    // Use this for initialization
	    void Start () {
            currentHealth = MaxHealth;
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        public void HandleDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                OnDeath();
            }
        }

        public void OnDeath() {
            GameObject explosion = (GameObject)Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
