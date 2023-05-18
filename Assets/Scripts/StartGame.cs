using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public TMP_InputField nameInput;

    private const string nameCheck = "Required";

    public void startGameClick()
    {
        if (nameInput.text.Length > 0 && nameInput.text != nameCheck)
        {
            DataManager.Instance.playerName = nameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            nameInput.text = nameCheck;
        }
    }
}
