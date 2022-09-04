using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogueScript : IEnumerable<DialogueScriptSnippet>
{
    public static DialogueScript FromFile(string path)
    {
        var textFile = Resources.Load<TextAsset>(path);
        
        return new DialogueScript
        {
            _snippets = textFile.text.Trim().Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(item => new DialogueScriptSnippet
            {
                Text = item
            }).ToList()
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
