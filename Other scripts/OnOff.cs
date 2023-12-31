using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject player;
    public GameObject[] objects;

    public GameObject[] HMDs;

    public GameObject[] images;
    public GameObject[] speeds;
    public GameObject[] times;

    public GameObject[] directions;

    public int activeIndex = -1;
    public bool passed = false;

    private SpawnTaxi spawnTaxi;

    // Start is called before the first frame update
    void Start() {
        spawnTaxi = FindAnyObjectByType<SpawnTaxi>();

        HMDs[0].SetActive(false);    // 시작시 HMD들 일단 비활성화
        HMDs[1].SetActive(false);
        Debug.Log("Start HMD off");

        for (int i = 0; i < objects.Length; i++) {
            objects[i].SetActive(false);
            images[i].SetActive(false);
            speeds[i].SetActive(false);
            times[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {

        for (int i = 0; i < objects.Length; i++) {
            if (objects[i].activeSelf == true) {
                if (activeIndex != i) {
                    activeIndex = i;
                    On();
                    Debug.Log("HMD" + i + " on");
                }
            }
        }

        bool hmdOff = spawnTaxi.GetHmdOff();

        if (hmdOff) {
            // player의 x 위치보다 크다면
            if (objects[activeIndex].activeSelf == true) {
                passed = true;
                Off();
                Debug.Log("HMD" + activeIndex + " off");
                hmdOff = false;
                Debug.Log("hmdOff: " + hmdOff);
            }
        }

    }

    void Off() {
        HMDs[0].SetActive(false);    // HMD들 비활성화
        HMDs[1].SetActive(false);
        images[activeIndex].SetActive(false);
        speeds[activeIndex].SetActive(false);
        times[activeIndex].SetActive(false);
        directions[0].SetActive(false);
    }

    void On() {
        HMDs[0].SetActive(true);    // HMD들 활성화
        HMDs[1].SetActive(true);
        images[activeIndex].SetActive(true);
        speeds[activeIndex].SetActive(true);
        times[activeIndex].SetActive(true);
        directions[0].SetActive(true);
    }


}
