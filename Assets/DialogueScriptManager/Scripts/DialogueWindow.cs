using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    private TextMeshProUGUI _dialogueText = null;
    private UnityEngine.UI.Image _dialogueBackground = null;

    public string Text
    {
        get => _dialogueText.text;
        set
        {
            _dialogueText.text = value;
            if (_dialogueText.text is not null)
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
        _dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        _dialogueBackground = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    public void Show()
    {
        DialogueHelper.PrefabShow(_dialogueText);
        DialogueHelper.PrefabShow(_dialogueBackground);
    }

    public void Hide()
    {
        DialogueHelper.PrefabHide(_dialogueText);
        DialogueHelper.PrefabHide(_dialogueBackground);
    }
}
