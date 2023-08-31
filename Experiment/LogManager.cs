using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    //public InputField playerNameInput;
    public TextMeshProUGUI playerNameInputText;
    public string playerName;
    private string logFilePath;
    private string resultFolderPath;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // "Result" ���� ��� ����
        resultFolderPath = Path.Combine(Application.persistentDataPath, "Result");

        // "Result" ������ ������ ����
        Directory.CreateDirectory(resultFolderPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveExperimentResult(string resultText) {
        // ���ϸ��� ��¥�� �ð����� ���� (�������� ����)
        string fileName = $"{playerName}_result_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

        // ���� ��� ����
        string filePath = Path.Combine(resultFolderPath, fileName);

        // ���� ����� ���Ͽ� ����
        File.WriteAllText(filePath, resultText);

        Debug.Log("Experiment result saved.");
    }

    // ���� ��� ������ �׽�Ʈ�غ��� �Լ� (����)
    private void TestSaveResult() {
        if (isGameOver) {
            string experimentResult = "This is the result of the experiment.";

            // ���� ����� �����ϴ� �Լ� ȣ��
            SaveExperimentResult(experimentResult);
        }
    }

    // ���� ���� �� "isGameOver" ���� true�� �����ϰ� ��� ������ �׽�Ʈ
    private void GameOver() {
        isGameOver = true;
        TestSaveResult();
    }
}
