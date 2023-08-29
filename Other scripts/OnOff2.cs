using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff2 : MonoBehaviour
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
    //private Spawn2 spawn2;
    private Spawn2 spawn2;

    // Start is called before the first frame update
    void Start() {
        spawn2 = FindAnyObjectByType<Spawn2>();

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
            if (objects[i].activeSelf == true && player.transform.position.x < objects[i].transform.position.x) {
                activeIndex = i;
                On(activeIndex);
                Debug.Log("HMD" + i + " on");
            }
        }

        bool hmdOff2 = spawn2.GetHmdOff();

        if (hmdOff2) {
            // player의 x 위치보다 크다면
            if (objects[activeIndex].activeSelf == true) {
                passed = true;
                Off(activeIndex);
                Debug.Log("HMD" + activeIndex + " off");
                hmdOff2 = false;
                Debug.Log("hmdOff2: " + hmdOff2);

            }
        }

    }

    void Off(int k) {
        HMDs[0].SetActive(false);    // HMD들 비활성화
        HMDs[1].SetActive(false);
        images[k].SetActive(false);
        speeds[k].SetActive(false);
        times[k].SetActive(false);
        directions[1].SetActive(false);
    }

    void On(int k) {
        HMDs[0].SetActive(true);    // HMD들 활성화
        HMDs[1].SetActive(true);
        images[k].SetActive(true);
        speeds[k].SetActive(true);
        times[k].SetActive(true);
        directions[1].SetActive(true);
    }

}
