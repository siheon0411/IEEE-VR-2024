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

    // ���� ����� txt������ �����ؼ� �����ϴ� �Լ�
    private void WritetxtFile(string resultText) {

        // "Result" ���� ��� ����
        resultFolderPath = Path.Combine(Application.persistentDataPath, "Result");

        // "Result" ������ ������ ����
        Directory.CreateDirectory(resultFolderPath);

        if (Directory.Exists(resultFolderPath)) {
            Debug.Log("Path exists" + resultFolderPath);
        } else {
            Debug.Log("Path doesn't exist");
        }


        string fileName = playerName + "_task" + taskNumber + "_result.txt";

        // ���� ��� ����
        string filePath = Path.Combine(resultFolderPath, fileName);

        Debug.Log(filePath);

        // ���� ����� ���Ͽ� ����
        File.WriteAllText(filePath, resultText);
    }

    // ���� ����� SpawnRepeat2���� �ҷ����� �Լ�
    public void SaveResult() {
            
        string experimentResult = "<Information>\n" + "Player Code: " + playerName + "\n" + "Task: " + taskNumber + "\n" + message;

        Debug.Log(experimentResult);

        // ���� ����� �����ϴ� �Լ� ȣ��
        WritetxtFile(experimentResult);

    }

    public void LogRecorder(string mes) {
        message += mes + "\n";
        Debug.Log("in LogManager: " + message);
    }

}
