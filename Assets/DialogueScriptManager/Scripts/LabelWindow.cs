using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabelWindow : MonoBehaviour
{
    private TextMeshProUGUI _textGUI = null;
    private UnityEngine.UI.Image _background = null;

    public string Text
    {
        get => _textGUI.text;
        set
        {
            _textGUI.text = value;
            if (_textGUI.text is not null)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

    }

    private void Awake()
    {
        _textGUI = GetComponentInChildren<TextMeshProUGUI>();
        _background = GetComponentInChildren<UnityEngine.UI.Image>();
    }
    
    public void Show()
    {
        DialogueHelper.PrefabShow(_textGUI);
        DialogueHelper.PrefabShow(_background);
    }

    public void Hide()
    {
        DialogueHelper.PrefabHide(_textGUI);
        DialogueHelper.PrefabHide(_background);
    }
}
