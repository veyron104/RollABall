using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public static ErrorMessage s_ErrorMessage;
    [SerializeField]
    GameObject _panel;
    [SerializeField]
    Text _msgText;

    void Awake()
    {
        s_ErrorMessage = this;
    }

    public void ShowMessage(string msg)
    {
        _msgText.text = msg;
        _panel.SetActive(true);
    }
}