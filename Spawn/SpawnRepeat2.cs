using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private float spawnPosZ;

    public GameObject directionArrow;

    private bool isSpawned = false;
    public bool hmdOff2 = false;
    private bool isPassed = false;
    private float timer = 0f;
    private bool timerOn = false;

    private float minSpawnInterval = 2.0f;
    private float maxSpawnInterval = 4.0f;

    public bool isGameOver = false;
    public GameObject endUI;
    public TextMeshProUGUI endText;


    // Start is called before the first frame update
    void Start()
    {
        endUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 타겟 포지션을 넘어갈 때 생성 시작
        if (player.transform.position.x < targetPositionX) {
            Debug.Log("over the target position");

            SpawnRandomVehicle();
        }

        // 생성된게 player 넘어가면 hmd 끄기
        if (vehicleObject != null && vehicleObject.transform.position.x < player.transform.position.x) {
            HmdController hmd = player.GetComponent<HmdController>();
            hmd.Off(vehicleIndex);

            Direction direction = directionArrow.GetComponent<Direction>();
            direction.Off();

            isPassed = true;
            if (!timerOn) {
                timerOn = true;
                float delaySeconds = Random.Range(minSpawnInterval, maxSpawnInterval);
                Debug.Log(delaySeconds);

                timer = Time.time + delaySeconds;
            }
        }

        if (isPassed && Time.time >= timer) {
            timerOn = false;
            isPassed = false;
            isSpawned = false;
            SpawnRandomVehicle();
        }

        // player가 엔드 포지션 넘어가면 게임 종료
        if (player.transform.position.x < endPositionX && !isGameOver) {
            isGameOver = true;

            Debug.Log("##### MISSION COMPLETE");
            Debug.Log("##### TOTAL SPAWNED OBJECTS: " + objectCount);

            DetectCollision detectCount = detectCollision.GetComponent<DetectCollision>();
            int count = detectCount.totalCount;

            Debug.Log("##### TOTAL CONTACT COUNTS: " + count);
            float contactRate = (float)count / (float)objectCount;
            Debug.Log("##### CONTACT RATE: " + contactRate*100 + "%");

            endUI.SetActive(true);
            endText.text = "Mission Complete\n" + "Total Objects: " + objectCount + "\n" + "Contact: " + count + "\n" + "Contact Rate: " + contactRate + "%";
        }
    }

    void SpawnRandomVehicle() {

        if (!isGameOver && !isSpawned) {
            vehicleIndex = Random.Range(vehicleIndexMin, vehicleIndexMax + 1);
            vehiclePrefabs[vehicleIndex].SetActive(true);

            spawnPosX = player.transform.position.x + Random.Range(10, 30);
            spawnPosZ = Random.Range(5.5f, 7.1f);
            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            vehicleObject = Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
            objectCount += 1;

            HmdController hmd = player.GetComponent<HmdController>();
            hmd.On(vehicleIndex, spawnPosZ);

            Direction direction = directionArrow.GetComponent<Direction>();
            direction.PosZ(spawnPosZ);
            direction.On();

            isSpawned = true;
        }

    }
}
