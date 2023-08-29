using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRepeat2 : MonoBehaviour
{
    public GameObject player;
    public float targetPositionX = 20;
    public float endPositionX = -35;
    private int objectCount = 0;
    public GameObject detectCollision;

    public GameObject[] vehiclePrefabs;
    public int vehicleIndex;
    public int vehicleIndexMin = 2;
    public int vehicleIndexMax = 4;
    private GameObject vehicleObject;

    private Vector3 spawnPos;
    private float spawnPosX;
    private float spawnPosY = 0;
    private float spawnPosZ = 6.078f;

    private bool isSpawned = false;
    public bool hmdOff2 = false;
    private bool isPassed = false;

    private float startDelay = 2.0f;
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 8.0f;

    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�� �������� �Ѿ �� ���� ����
        if (player.transform.position.x < targetPositionX) {
            Debug.Log("over the target position");

            SpawnRandomVehicle();
        }

        // �����Ȱ� player �Ѿ�� hmd ����
        if (vehicleObject != null && vehicleObject.transform.position.x < player.transform.position.x) {
            HmdController hmd = player.GetComponent<HmdController>();
            hmd.Off(vehicleIndex);
            isPassed = true;
        }

        if (isPassed) {
            isSpawned = false;
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);
            isPassed = false;
        }

        // player�� ���� ������ �Ѿ�� ���� ����
        if (player.transform.position.x < endPositionX) {
            isGameOver = true;

            Debug.Log("##### MISSION COMPLETE");
            Debug.Log("##### TOTAL SPAWNED OBJECTS: " + objectCount);

            DetectCollision detectCount = detectCollision.GetComponent<DetectCollision>();
            int count = detectCount.totalCount;

            Debug.Log("##### TOTAL CONTACT COUNTS: " + count);
            float contactRate = (float)count / (float)objectCount;
            Debug.Log("##### CONTACT RATE: " + contactRate*100 + "%");
        }
    }

    void SpawnRandomVehicle() {

        if (!isGameOver && !isSpawned) {
            vehicleIndex = Random.Range(vehicleIndexMin, vehicleIndexMax + 1);
            vehiclePrefabs[vehicleIndex].SetActive(true);

            spawnPosX = player.transform.position.x + Random.Range(10, 30);
            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            vehicleObject = Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
            objectCount += 1;

            HmdController hmd = player.GetComponent<HmdController>();
            hmd.On(vehicleIndex);

            isSpawned = true;
        }

    }
}
