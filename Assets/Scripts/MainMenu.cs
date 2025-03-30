using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

using TMPro;

public class MainMenu : MonoBehaviour
{
    //PersistentData pData;
    public TMP_InputField pNameText;

    public void LateStart()
    {
        //pData = GameObject.Find("PersistentData").GetComponent<PersistentData>();
        pNameText = GameObject.Find("PlayerNameText").GetComponent<TMP_InputField>();

        pNameText.text = PersistentData.pName;
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("main");

        //Debug.Log(pNameText.text);

        if (pNameText.text.Length > 0)
        {
            PersistentData.pName = pNameText.text; 
        }        
    }


    public void OnExitClick()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }

}
