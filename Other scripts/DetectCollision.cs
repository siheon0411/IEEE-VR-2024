using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private int totalCount = 0;
    private int carCount = 0;
    private int twoCount = 0;
    public bool isContact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Car")) {
            isContact = true;
            carCount += 1;
            totalCount += 1;
            Debug.Log("Contact with Car: " + carCount);
            Debug.Log("Total contact: " + totalCount);

        } else if (other.CompareTag("Two")) {
            isContact = true;
            twoCount += 1;
            totalCount += 1;
            Debug.Log("Contact with two-wheels: " + twoCount);
            Debug.Log("Total contact: " + totalCount);
        }

    }
}
