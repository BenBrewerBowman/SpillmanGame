using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame
{
    public class PlayerScript : MonoBehaviour
    {

        private GameManager manager;

        void Start()
        {
            manager = GameManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
      }
}
