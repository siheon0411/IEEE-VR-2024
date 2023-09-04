using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int totalCount = 0;
    public int carCount = 0;
    public int twoCount = 0;

    public int cycleCount = 0;
    public int kickboardCount = 0;
    public int motorcycleCount = 0;

    public bool isContact;

    public GameObject endUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {

        LogManager logManager = endUI.GetComponent<LogManager>();
        
        if (other.CompareTag("Car")) {
            isContact = true;
            carCount += 1;
            totalCount += 1;
            Debug.Log("Contact with Car: " + carCount);
            Debug.Log("Total contact: " + totalCount);
            logManager.LogRecorder("Contact with Car: " + carCount + "\n" + "Total contact: " + totalCount);

        } else if (other.CompareTag("Cycle")) {
            isContact = true;
            cycleCount += 1;
            twoCount += 1;
            totalCount += 1;
            Debug.Log("Contact with Cycle: " + cycleCount);
            Debug.Log("Total contact: " + totalCount);
            logManager.LogRecorder("Contact with Cycle: " + cycleCount + "\n" + "Total contact: " + totalCount);

        } else if (other.CompareTag("Kickboard")) {
            isContact = true;
            kickboardCount += 1;
            twoCount += 1;
            totalCount += 1;
            Debug.Log("Contact with Kickboard: " + kickboardCount);
            Debug.Log("Total contact: " + totalCount);
            logManager.LogRecorder("Contact with Kickboard: " + kickboardCount + "\n" + "Total contact: " + totalCount);

        } else if (other.CompareTag("Motorcycle")) {
            isContact = true;
            motorcycleCount += 1;
            twoCount += 1;
            totalCount += 1;
            Debug.Log("Contact with Motorcycle: " + motorcycleCount);
            Debug.Log("Total contact: " + totalCount);
            logManager.LogRecorder("Contact with Motorcycle: " + motorcycleCount + "\n" + "Total contact: " + totalCount);

        }

    }

}
