using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public float spawnPosX = 0;
    public float spawnPosY = 0;
    public float spawnPosZ = 0;

    private float startDelay = 4;
    private float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update() {

    }
    void SpawnRandomVehicle() {
        int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
    }
}
