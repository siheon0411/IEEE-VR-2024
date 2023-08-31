using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public TextMeshProUGUI inputText;
    public TMP_InputField inputField;
    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputButton() {
        playerName = inputText.text;
        SpawnRepeat2 spawnRepeat2 = GetComponent<SpawnRepeat2>();
        spawnRepeat2.playerName = playerName;

    }
}
