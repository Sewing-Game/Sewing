using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTestSceneManager : MonoBehaviour
{
    public string scriptPath = "Assets/Resources/Dialogues/ko/0. Test Dialogue.txt";
    private DialogueScriptManager _dialogueScriptManager;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueScriptManager = FindObjectOfType<DialogueScriptManager>();
        _dialogueScriptManager.Load(scriptPath);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
