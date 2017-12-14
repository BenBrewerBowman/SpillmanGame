using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class basicAI : MonoBehaviour
    {
        public NavMeshAgent agent;
        public ThirdPersonCharacter character;
        
        public enum State{
            PATROL,
            CHASE,
            SHOOT
        }

        public State state;
        private bool alive;

        //Variables for shooting
        private static string rightShoulderPath = "EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanRightShoulder";
        private static string rightForeArmPath = "EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanRightShoulder/EthanRightArm/EthanRightForeArm";
        private static string rightArmPath = "EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanRightShoulder/EthanRightArm";
        private static string skeletonPath = "EthanSkeleton";
        private static string bulletPath = "EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2/EthanNeck/EthanRightShoulder/EthanRightArm/EthanRightForeArm/EthanRightHand/GUN_UNITY/Sphere";
        private int shootTime;
        bool shooting = false;
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        //Variables for patrolling
        public GameObject[] waypoints;
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;

        //Variables for chasing 
        public float chaseSpeed = 1f;
        public GameObject target;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            state = basicAI.State.PATROL;
            shootTime = 0;
            alive = true;

            
        }

        void LateUpdate()
        {
            StartCoroutine("FSM");
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                    case State.SHOOT:
                        Shoot();
                        break;
                }
                yield return null; 
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if(Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd += 1;
                if (waypointInd > waypoints.Length-1)
                {
                    waypointInd = 0;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }

        void Shoot()
        {
           

            character.Move(Vector3.zero, false, false);
            agent.SetDestination(character.transform.position);
            GameObject arm = transform.Find(rightArmPath).gameObject;
            GameObject forearm = transform.Find(rightForeArmPath).gameObject;
            GameObject shoulder = transform.Find(rightShoulderPath).gameObject;
            GameObject skeleton = transform.Find(skeletonPath).gameObject;
            arm.transform.Rotate(-55f, 0, 0);
            forearm.transform.Rotate(-22f, 0, 0);
            skeleton.transform.LookAt(target.transform);
            if(shootTime <= 10000)
            {
                shootTime += 1;
            }
            else
            {
                shootTime = 0;
                Fire();
            }
            //shoulder.transform.Rotate(29.4f, 64.22601f, -173.519f);
        }

        void Fire()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }

        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);
            
        }

        void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "Player")
            {
                state = basicAI.State.SHOOT;
                target = coll.gameObject;
            }
        }
    }
}

