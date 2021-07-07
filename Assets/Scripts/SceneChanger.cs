using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public  static void LoseMenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void StartStage()
    {
        SceneManager.LoadScene("Stage");
    }
}
