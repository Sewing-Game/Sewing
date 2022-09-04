using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueScriptManager : MonoBehaviour
{
    private DialogueScript _currentScript;
    private IEnumerator<DialogueScriptSnippet> _enumerator;
    private DialogueWindow _dialogueWindow;

    public void Awake()
    {
        _dialogueWindow = GetComponentInChildren<DialogueWindow>();
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_dialogueWindow.TextDisplayed)
            {
                Next();
            }
            else
            {
                _dialogueWindow.Skip();
            }
        }
    }

    public void Load(string path)
    {
        _currentScript = DialogueScript.FromFile(path);
        _enumerator = _currentScript.GetEnumerator();
        _enumerator.Reset();
        _dialogueWindow.WindowShow();
        Next();
    }

    public bool Next()
    {
        var result = _enumerator.MoveNext();
        if (result)
        {
            _dialogueWindow.Text = _enumerator.Current.Text;
        }
        else
        {
            _dialogueWindow.WindowHide();
        }

        return result;
    }
}
