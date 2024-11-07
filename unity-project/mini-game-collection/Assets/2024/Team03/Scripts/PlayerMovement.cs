using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Numerics;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class PlayerMovement : MonoBehaviour
    {

        public Transform transform;

        public float movementSpeed = 0.5f;
        //public Vector3 playerStartPos;
        //public Vector3 playerStartRot;

        private void Start()
        {
            //playerStartPos = new Vector3(22.8260002f, 1.53900003f, -8.89000034f);
            //playerStartRot = new Vector3(0, 0, 0);
        }



        void Update()
        {
            MoveRight();
        }



        //Movements
        public void MoveRight()
        {
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveBackwards()
        {
            transform.position = transform.position + new Vector3(0, 0, -movementSpeed * Time.deltaTime);


        }
    }
}
