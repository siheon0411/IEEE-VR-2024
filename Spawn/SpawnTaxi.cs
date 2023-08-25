using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnTaxi : MonoBehaviour
{
    public GameObject player;
    public float targetPositionX = 40;
    public int vehicleSpawnNumber = 0;

    public GameObject car;
    private GameObject carObject;

    public Vector3 spawnPos = new Vector3(0, 0, 0);

    public bool hmdOff = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < targetPositionX) {
            Debug.Log("over the target position");
            car.SetActive(true);
            SpawnVehicle();

        }

        if (carObject.transform.position.x < player.transform.position.x) {
            hmdOff = true;
        }
    }

    public bool GetHmdOff() {
        return hmdOff;
    }

    void SpawnVehicle() {

        if (vehicleSpawnNumber == 0) {
            carObject = Instantiate(car, spawnPos, car.transform.rotation);
            vehicleSpawnNumber = 1;
        }
    }
}
