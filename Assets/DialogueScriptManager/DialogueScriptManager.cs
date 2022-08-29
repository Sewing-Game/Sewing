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

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }

    public void Load(string path)
    {
        _currentScript = DialogueScript.FromFile(path);
        _enumerator = _currentScript.GetEnumerator();
        _enumerator.Reset();
        _dialogueWindow.Show();
        Next();
    }

    public bool Next()
    {
        var result = _enumerator.MoveNext();
        Debug.Log(result);
        if (result)
        {
            _dialogueWindow.Text = _enumerator.Current.Text;
        }
        else
        {
            _dialogueWindow.Hide();
        }

        return result;
    }
}
