using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team03
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        // Time delay before destroying the GameObject
        public float delay = 0.2f;

        // Start is called before the first frame update
        void Start()
        {
            // Destroy the current GameObject after the specified delay
            Destroy(gameObject, delay);
        }
    }
}
