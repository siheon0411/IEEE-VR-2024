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
        // �α� ���� ��� ���� (Application.persistentDataPath�� Ȱ���Ͽ� ����)
        logFilePath = Path.Combine(Application.persistentDataPath, "Experiment_" + name + ".txt");

        // �α� �޽����� ���� ������ �Լ� ȣ���ϵ��� ������ ���
        Application.logMessageReceived += HandleLog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleLog(string logString, string stackTrace, LogType type) {
        // �α� �޽����� ���Ͽ� �����ϴ� �Լ� ȣ��
        SaveLogToFile(logString);
    }

    public void SaveLogToFile(string log) {
        // �α׸� ���Ͽ� �߰� ����
        using (StreamWriter writer = File.AppendText(logFilePath)) {
            writer.WriteLine(log);
        }
    }
}
