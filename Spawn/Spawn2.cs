using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public GameObject player;
    public float targetPositionX = 16;
    public int vehicleSpawnNumber = 0;

    public GameObject[] vehiclePrefabs;
    private GameObject vehicleObject;

    public Vector3 spawnPos = new Vector3(0, 0, 0);

    public bool hmdOff2 = false;

    //private float startDelay = 4;
    //private float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start() {
        //InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x < targetPositionX) {
            Debug.Log("over the target position");
            vehicleObject.SetActive(true);
            SpawnRandomVehicle();

        }

        if (vehicleObject.transform.position.x < player.transform.position.x) {
            hmdOff2 = true;
        }

    }

    public bool GetHmdOff() {
        return hmdOff2;
    }

    void SpawnRandomVehicle() {
        int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);

        if (vehicleSpawnNumber == 0) {
            vehicleObject = Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
            vehicleSpawnNumber = 1;
        }

    }
}
