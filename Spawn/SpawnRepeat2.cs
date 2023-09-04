using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRepeat2 : MonoBehaviour
{
    public string playerName = null;

    public GameObject player;
    public float targetPositionX;
    public float endPositionX;
    private int objectCount = 0;
    public GameObject detectCollision;

    public GameObject[] vehiclePrefabs;
    public int vehicleIndex;
    public int vehicleIndexMin = 2;
    public int vehicleIndexMax = 4;
    private GameObject vehicleObject;

    public float objectSpeed;
    public float gap;
    public float estimatedTime;

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
                //Debug.Log(delaySeconds);

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

            DetectCollision detectCount = detectCollision.GetComponent<DetectCollision>();
            int count = detectCount.totalCount;

            float contactRate = (float)count / (float)objectCount * 100;

            string finalText = "<Mission Complete>\n" + "Player: " + playerName + "\n" + "Total Objects: " + objectCount + "\n" + "Contact: " + count + "\n" + "Contact Rate: " + contactRate + "%";
            endUI.SetActive(true);
            endText.text = finalText;

            Debug.Log("##### " + finalText);

            LogManager logManager = endUI.GetComponent<LogManager>();
            logManager.LogRecorder("\n" + finalText);
            logManager.SaveResult();


        }
    }

    void SpawnRandomVehicle() {

        if (!isGameOver && !isSpawned) {

            LogManager logManager = endUI.GetComponent<LogManager>();
            if (logManager.taskNumber == "2" || logManager.taskNumber == "4" || logManager.taskNumber == "6") {
                vehicleIndex = Random.Range(vehicleIndexMin, vehicleIndexMax + 1);
            } else {
                vehicleIndex = Random.Range(0, 2);
            }
            Debug.Log("vehicle index: " +  vehicleIndex);
            vehiclePrefabs[vehicleIndex].SetActive(true);

            // spawnPosX 설정
            gap = Random.Range(10, 30);
            if (logManager.taskNumber == "2" || logManager.taskNumber == "4" || logManager.taskNumber == "6") {
                spawnPosX = player.transform.position.x + gap;
            } else {
                spawnPosX = 53.0f;
            }

            // spawnPosZ 설정
            if (logManager.taskNumber == "2" || logManager.taskNumber == "4" || logManager.taskNumber == "6") {
                spawnPosZ = Random.Range(5.5f, 7.1f);
            } else {
                spawnPosZ = 3.3f;
            }
            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            // object별 속도 설정 -> 1 Unity Speed = 1m/s = 3.6km/h
            // car:         30~50km/h   -> 8.33~13.88
            // cycle:       15~30km/h   -> 4.16~8.33
            // kickboard:   15~25km/h   -> 4.16~6.94
            // motorcycle:  20~50km/h   -> 5.55~13.88

            //if (vehicleIndex == 0) {            // car_builders
            //    objectSpeed = Random.Range(8.33f, 13.88f);
            //} else if (vehicleIndex == 1) {     // car_taxi
            //    objectSpeed = Random.Range(8.33f, 13.88f);
            //} else if (vehicleIndex == 2) {     // cyclist
            //    objectSpeed = Random.Range(4.16f, 8.33f);
            //} else if (vehicleIndex == 3) {     // kickboard
            //    objectSpeed = Random.Range(4.16f, 6.94f);
            //} else if (vehicleIndex == 4) {     // motorcycle
            //    objectSpeed = Random.Range(5.55f, 13.88f);
            //} else {                            // toy cars
            //    objectSpeed = Random.Range(8.33f, 13.88f);
            //}

            vehicleObject = Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
            objectCount += 1;

            if (vehicleIndex == 2) {                    // cyclist
                objectSpeed = 6.94f;
            } else if (vehicleIndex == 3) {             // kickboard
                objectSpeed = 6.94f;
            } else if (vehicleIndex == 4) {             // motorcycle
                objectSpeed = 13.88f;
            } else {                                    // cars
                objectSpeed = 13.88f;
            }

            objectSpeed = objectSpeed * 3.6f;

            estimatedTime = gap / objectSpeed;

            if (logManager.taskNumber == "3" || logManager.taskNumber == "4" || logManager.taskNumber == "5" || logManager.taskNumber == "6") {

                HmdController hmd = player.GetComponent<HmdController>();
                hmd.On(vehicleIndex, spawnPosZ, objectSpeed, estimatedTime);

                Direction direction = directionArrow.GetComponent<Direction>();
                direction.PosZ(spawnPosZ);
                direction.On();

            }

            isSpawned = true;
        }

    }
}
