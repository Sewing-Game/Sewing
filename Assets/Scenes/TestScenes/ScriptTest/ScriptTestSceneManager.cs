using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTestSceneManager : MonoBehaviour
{
    public string scriptPath = "Assets/Resources/Dialogues/ko/0. Test Dialogue.json";
    private DialogueManager _dialogueScriptManager;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueScriptManager = FindObjectOfType<DialogueManager>();
        _dialogueScriptManager.Load(scriptPath);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
