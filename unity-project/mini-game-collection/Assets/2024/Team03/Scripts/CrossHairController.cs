using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class CrossHairController : MonoBehaviour
    {
        public RectTransform p1CrossHair, p2Crosshair;  // The RectTransform of the CrossHairs (UI element)
        public float moveSpeed = 10f;    // Speed of CrossHair movement
        public Camera playerCamera;      // Reference to the player's camera
        public float rayDistance = 10000f;  // Distance the ray will travel
        public LayerMask enemyLayer;     // Layer mask to detect only enemies
        public LayerMask hostageLayer;   // Layer mask to detect only hostages

        private Vector2 screenBounds;    // Store screen bounds for limiting movement

        void Start()
        {
            // Initialize screen bounds (confines the CrossHair within the screen size)
            screenBounds = new Vector2(Screen.width, Screen.height);
        }

        void Update()
        {
            // Move the CrossHair
            MoveP1CrossHair();
            MoveP2CrossHair();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ShootP2Raycast();
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                ShootP1Raycast();
            }
        }

        void MoveP1CrossHair()
        {
            // Get CrossHair's current position
            Vector2 p1CrossHairPos = p1CrossHair.position;

            // Update CrossHair position based on arrow key input
            if (Input.GetKey(KeyCode.UpArrow))
                p1CrossHairPos.y += moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow))
                p1CrossHairPos.y -= moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftArrow))
                p1CrossHairPos.x -= moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow))
                p1CrossHairPos.x += moveSpeed * Time.deltaTime;

            // Make sure the CrossHair stays within screen bounds
            p1CrossHairPos.x = Mathf.Clamp(p1CrossHairPos.x, 0, screenBounds.x);
            p1CrossHairPos.y = Mathf.Clamp(p1CrossHairPos.y, 0, screenBounds.y);

            // Update the position of the CrossHair
            p1CrossHair.position = p1CrossHairPos;
        }

        void MoveP2CrossHair()
        {
            // Get CrossHair's current position
            Vector2 p2CrossHairPos = p2Crosshair.position;

            // Update CrossHair position based on arrow key input
            if (Input.GetKey(KeyCode.W))
                p2CrossHairPos.y += moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                p2CrossHairPos.y -= moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
                p2CrossHairPos.x -= moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                p2CrossHairPos.x += moveSpeed * Time.deltaTime;

            // Make sure the CrossHair stays within screen bounds
            p2CrossHairPos.x = Mathf.Clamp(p2CrossHairPos.x, 0, screenBounds.x);
            p2CrossHairPos.y = Mathf.Clamp(p2CrossHairPos.y, 0, screenBounds.y);

            // Update the position of the CrossHair
            p2Crosshair.position = p2CrossHairPos;
        }

        void ShootP1Raycast()
        {
            // Create a ray from the camera's position in the forward direction
            Ray p1Ray = playerCamera.ScreenPointToRay(p1CrossHair.position); // Cast ray from CrossHair screen position
            Debug.DrawRay(transform.position, transform.forward, Color.green);

            RaycastHit p1Hit;

            if (Physics.Raycast(p1Ray, out p1Hit, rayDistance, enemyLayer))
            {
                Debug.Log("P1 Hit enemy: " + p1Hit.collider.name);
                //hit.collider.GetComponent<Enemy>().TakeDamage(10);
            }
            else if (Physics.Raycast(p1Ray, out p1Hit, rayDistance, hostageLayer))
            {
                Debug.Log("P1 Hit hostage: " + p1Hit.collider.name);
            }
            else
            {
                Debug.Log("P1 Nothing hit.");
            }
        }

        void ShootP2Raycast()
        {
            // Create a ray from the camera's position in the forward direction
            Ray p2Ray = playerCamera.ScreenPointToRay(p2Crosshair.position); // Cast ray from CrossHair screen position
            Debug.DrawRay(transform.position, transform.forward, Color.green);


            RaycastHit p2Hit;
            if (Physics.Raycast(p2Ray, out p2Hit, rayDistance, enemyLayer))
            {
                Debug.Log("P2 Hit enemy: " + p2Hit.collider.name);
                //hit.collider.GetComponent<Enemy>().TakeDamage(10);
            }
            else if (Physics.Raycast(p2Ray, out p2Hit, rayDistance, hostageLayer))
            {
                Debug.Log("P2 Hit hostage: " + p2Hit.collider.name);
            }
            else
            {
                Debug.Log("P2 Nothing hit.");
            }
        }
    }
}
