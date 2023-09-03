using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;

    public TMP_InputField inputField;
    public TextMeshProUGUI inputText;
    
    private string playerCode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateInputText(string newText) {
        string currentText = inputField.text;
        string combinedText = currentText + newText;

        inputField.text = combinedText;
        Debug.Log("InputField: " + inputField.text);

        playerCode = inputField.text;
        Debug.Log("PlayerCode: " + playerCode);
    }

    public void InputButton() {
        playerCode = inputField.text;
        SpawnRepeat2 spawnRepeat2 = spawn.GetComponent<SpawnRepeat2>();
        spawnRepeat2.playerName = playerCode;

        HmdController controller = player.GetComponent<HmdController>();
        controller.HMDs[2].SetActive(false);
    }

    public void KeyBoard0() {
        string dial = "0";
        UpdateInputText(dial);
    }

    public void KeyBoard1() {
        string dial = "1";
        UpdateInputText(dial);
    }
    public void KeyBoard2() {
        string dial = "2";
        UpdateInputText(dial);
    }
    public void KeyBoard3() {
        string dial = "3";
        UpdateInputText(dial);
    }
    public void KeyBoard4() {
        string dial = "4";
        UpdateInputText(dial);
    }
    public void KeyBoard5() {
        string dial = "5";
        UpdateInputText(dial);
    }
    public void KeyBoard6() {
        string dial = "6";
        UpdateInputText(dial);
    }
    public void KeyBoard7() {
        string dial = "7";
        UpdateInputText(dial);
    }
    public void KeyBoard8() {
        string dial = "8";
        UpdateInputText(dial);
    }
    public void KeyBoard9() {
        string dial = "9";
        UpdateInputText(dial);
    }
    public void KeyBoardDash() {
        string dial = "-";
        UpdateInputText(dial);
    }
}
