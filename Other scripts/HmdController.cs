using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HmdController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] objects;

    public GameObject[] HMDs;

    public GameObject[] images;
    public GameObject[] speeds;
    public GameObject[] times;

    public GameObject[] directions;


    // Start is called before the first frame update
    void Start() {

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

    }


    public void Off(int k) {
        HMDs[0].SetActive(false);    // HMD들 비활성화
        HMDs[1].SetActive(false);
        images[k].SetActive(false);
        speeds[k].SetActive(false);
        times[k].SetActive(false);
        if (k == 0 || k == 1) {
            directions[0].SetActive(false);
        } else if (k == 2 || k == 3 || k == 4) {
            directions[1].SetActive(false);
        }
    }

    public void On(int k) {
        HMDs[0].SetActive(true);    // HMD들 활성화
        HMDs[1].SetActive(true);
        images[k].SetActive(true);
        speeds[k].SetActive(true);
        times[k].SetActive(true);
        if (k == 0 || k == 1) {
            directions[0].SetActive(true);
        } else if (k == 2 || k == 3 || k == 4) {
            directions[1].SetActive(true);
        }
    }
}
