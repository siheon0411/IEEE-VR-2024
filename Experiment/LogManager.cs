using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public GameObject player;

    public string playerName;
    public string taskNumber;

    private string message = "\n<Experiment Result>\n";

    private string resultFolderPath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 실험 결과를 txt파일을 생성해서 저장하는 함수
    private void WritetxtFile(string resultText) {

        // "Result" 폴더 경로 설정
        resultFolderPath = Path.Combine(Application.persistentDataPath, "Result");

        // "Result" 폴더가 없으면 생성
        Directory.CreateDirectory(resultFolderPath);

        if (Directory.Exists(resultFolderPath)) {
            Debug.Log("Path exists" + resultFolderPath);
        } else {
            Debug.Log("Path doesn't exist");
        }


        string fileName = playerName + "_task" + taskNumber + "_result.txt";

        // 파일 경로 설정
        string filePath = Path.Combine(resultFolderPath, fileName);

        Debug.Log(filePath);

        // 실험 결과를 파일에 저장
        File.WriteAllText(filePath, resultText);
    }

    // 실험 결과를 SpawnRepeat2에서 불러오는 함수
    public void SaveResult() {
            
        string experimentResult = "<Information>\n" + "Player Code: " + playerName + "\n" + "Task: " + taskNumber + "\n" + message;

        Debug.Log(experimentResult);

        // 실험 결과를 저장하는 함수 호출
        WritetxtFile(experimentResult);

    }

    public void LogRecorder(string mes) {
        message += mes + "\n";
        Debug.Log("in LogManager: " + message);
    }

}
