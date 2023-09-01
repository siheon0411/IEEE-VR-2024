using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI inputText;
    
    private string playerCode;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateInputText);
    }

    // Update is called once per frame
    void Update()
    {
        inputText.text = playerCode;
    }

    public void UpdateInputText(string newText) {
        string currentText = inputField.text;
        string combinedText = currentText + newText;

        inputField.text = combinedText;
    }

    public void InputButton() {
        inputText.text = playerCode;
        SpawnRepeat2 spawnRepeat2 = GetComponent<SpawnRepeat2>();
        spawnRepeat2.playerName = playerCode;

        HmdController controller = GetComponent<HmdController>();
        controller.HMDs[2].SetActive(false);

    }

    public void KeyBoard0() {
        string dial = "0";
        UpdateInputText(dial);
    }

    public void KeyBoard1() {
        string dial = "1";
        inputText.text += dial;
    }
    public void KeyBoard2() {
        string dial = "2";
        inputText.text += dial;
    }
    public void KeyBoard3() {
        string dial = "3";
        inputText.text += dial;
    }
    public void KeyBoard4() {
        string dial = "4";
        inputText.text += dial;
    }
    public void KeyBoard5() {
        string dial = "5";
        inputText.text += dial;
    }
    public void KeyBoard6() {
        string dial = "6";
        inputText.text += dial;
    }
    public void KeyBoard7() {
        string dial = "7";
        inputText.text += dial;
    }
    public void KeyBoard8() {
        string dial = "8";
        inputText.text += dial;
    }
    public void KeyBoard9() {
        string dial = "9";
        inputText.text += dial;
    }
    public void KeyBoardDash() {
        string dial = "-";
        inputText.text += dial;
    }
}
