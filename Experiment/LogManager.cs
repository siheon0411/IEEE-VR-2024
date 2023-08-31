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
        // "Result" 폴더 경로 설정
        resultFolderPath = Path.Combine(Application.persistentDataPath, "Result");

        // "Result" 폴더가 없으면 생성
        Directory.CreateDirectory(resultFolderPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveExperimentResult(string resultText) {
        // 파일명을 날짜와 시간으로 생성 (고유성을 위해)
        string fileName = $"{playerName}_result_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

        // 파일 경로 설정
        string filePath = Path.Combine(resultFolderPath, fileName);

        // 실험 결과를 파일에 저장
        File.WriteAllText(filePath, resultText);

        Debug.Log("Experiment result saved.");
    }

    // 실험 결과 저장을 테스트해보는 함수 (예시)
    private void TestSaveResult() {
        if (isGameOver) {
            string experimentResult = "This is the result of the experiment.";

            // 실험 결과를 저장하는 함수 호출
            SaveExperimentResult(experimentResult);
        }
    }

    // 게임 오버 시 "isGameOver" 값을 true로 설정하고 결과 저장을 테스트
    private void GameOver() {
        isGameOver = true;
        TestSaveResult();
    }
}
