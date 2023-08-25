using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 60.0f;
    private float lowerBound = -60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound) {
            Destroy(gameObject);
        } else if (transform.position.x < lowerBound) {
            Destroy(gameObject);
        }
    }
}
