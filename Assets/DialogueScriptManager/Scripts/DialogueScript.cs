using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogueScript : IEnumerable<DialogueScriptSnippet>
{
    private static JsonSerializer _jsonSerializer = JsonSerializer.CreateDefault();
    public static DialogueScript FromFile(string path)
    {        
        var textFile = Resources.Load<TextAsset>(path);
        using var reader = new JsonTextReader(new StringReader(textFile.text));
        return new DialogueScript
        {
            _snippets = _jsonSerializer.Deserialize<DialogueScriptSnippet[]>(reader)
        };
    }

    private IEnumerable<DialogueScriptSnippet> _snippets;

    private DialogueScript() { }

    public IEnumerator<DialogueScriptSnippet> GetEnumerator()
    {
        return _snippets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
