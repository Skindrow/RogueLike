using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button startButton;

    public void Start()
    {
        Button startButtonGO = startButton.GetComponent<Button>();
        startButtonGO.onClick.AddListener(StartButtonClick);
    }
    public void StartButtonClick()
    {
        SceneChanger.StartStage();
    }
}
