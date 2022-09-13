using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private DialogueScript _currentScript;
    private IEnumerator<DialogueScriptSnippet> _enumerator;
    private DialogueUI _dialogueUi;

    public void Awake()
    {
        _dialogueUi = GetComponentInChildren<DialogueUI>();
    }

    public void Start()
    {
        _dialogueUi.WindowHide();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_dialogueUi.TextDisplayed)
            {
                Next();
            }
            else
            {
                _dialogueUi.Skip();
            }
        }
    }

    public void Load(string path)
    {
        _currentScript = DialogueScript.FromFile(path);
        _enumerator = _currentScript.GetEnumerator();
        _enumerator.Reset();
        Next();
    }

    public bool Next()
    {
        var result = _enumerator.MoveNext();
        if (result)
        {
            _dialogueUi.LabelText = _enumerator.Current.Label;
            _dialogueUi.DialogueText = _enumerator.Current.Text;
        }
        else
        {
            _dialogueUi.WindowHide();
        }

        return result;
    }
}
