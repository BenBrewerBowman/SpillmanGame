using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame
{

    public class BulletScript : MonoBehaviour
    {

        public float Damage = 50.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Enemy")
            {
                Damageable enemy = other.gameObject.GetComponent<EnemyScript>();
                enemy.HandleDamage(Damage);
                Debug.Log("Dealing damage to enemy");
            }
        }
    }
}

