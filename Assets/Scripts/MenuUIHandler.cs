using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text BestScoreText;

    private void Start()
    {
        BestScoreText.text = "The best score is " + DataPersistance.Instance.bestScore + " from " + DataPersistance.Instance.bestPlayer + "!";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataPersistance.Instance.SaveInformations();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
