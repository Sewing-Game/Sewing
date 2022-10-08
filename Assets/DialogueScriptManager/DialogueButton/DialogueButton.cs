using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    private string _text { get; set; }
    private TextMeshProUGUI _textUI;
    public string Text
    {
        get
        {
            return _textUI.gameObject.activeSelf ? _textUI.text : _text;
        }
        set
        {
            if (_textUI.gameObject.activeSelf)
            {
                _textUI.text = value;
            }
            else
            {
                _text = value;
            }
        }
    }

    private void Awake()
    {
        _textUI = GetComponentInChildren<TextMeshProUGUI>();
        _textUI.text = _text;
    }

    private void Start()
    {
    }
}
