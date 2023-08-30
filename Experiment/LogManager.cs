using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public string name = "Prototype";
    private string logFilePath;

    // Start is called before the first frame update
    void Start()
    {
        // 로그 파일 경로 설정 (Application.persistentDataPath를 활용하여 저장)
        logFilePath = Path.Combine(Application.persistentDataPath, "Experiment_" + name + ".txt");

        // 로그 메시지를 받을 때마다 함수 호출하도록 리스너 등록
        Application.logMessageReceived += HandleLog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleLog(string logString, string stackTrace, LogType type) {
        // 로그 메시지를 파일에 저장하는 함수 호출
        SaveLogToFile(logString);
    }

    public void SaveLogToFile(string log) {
        // 로그를 파일에 추가 저장
        using (StreamWriter writer = File.AppendText(logFilePath)) {
            writer.WriteLine(log);
        }
    }
}
