using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HmdController : MonoBehaviour
{
    public GameObject player;
    public GameObject endUI;

    private float playerPosZ;

    public GameObject[] objects;

    public GameObject[] HMDs;

    public GameObject[] images;

    public GameObject speeds;
    public TextMeshProUGUI speedText;

    public GameObject times;
    public TextMeshProUGUI timeText;

    public GameObject[] directions;

    public GameObject directionArrow;


    // Start is called before the first frame update
    void Start() {
        directionArrow.SetActive(false);

        HMDs[0].SetActive(false);    // 시작시 HMD들 일단 비활성화
        HMDs[1].SetActive(false);
        Debug.Log("Start HMD off");

        directions[0].SetActive(false);
        directions[1].SetActive(false);

        speeds.SetActive(false);
        times.SetActive(false);

        for (int i = 0; i < objects.Length; i++) {
            objects[i].SetActive(false);
            images[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update() {
        playerPosZ = player.transform.position.z;
    }


    public void Off(int k) {
        HMDs[0].SetActive(false);    // HMD들 비활성화
        HMDs[1].SetActive(false);
        //HMDs[2].SetActive(false);

        directions[0].SetActive(false);
        directions[1].SetActive(false);

        images[k].SetActive(false);
        speeds.SetActive(false);
        times.SetActive(false);
    }

    public void On(int k, float z, float speed, float time) {

        LogManager logManager = endUI.GetComponent<LogManager>();

        HMDs[0].SetActive(true);    // HMD들 활성화
        HMDs[1].SetActive(true);
        images[k].SetActive(true);
        if (logManager.taskNumber == "5" || logManager.taskNumber == "6") {
            speeds.SetActive(true);
            speedText.text = Mathf.Round(speed) + "km/h";
            times.SetActive(true);
            timeText.text = "contact in " + Mathf.Round(time) + " sec";
        }
        
        if (playerPosZ < z && z > 6.0f) {
            directions[0].SetActive(true);
            //Debug.Log("Directions left ON");
        } else {
            directions[1].SetActive(true);
            //Debug.Log("Directions right ON");
        }
    }
}
