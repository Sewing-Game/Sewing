using System;
using System.Collections.Generic;

[Serializable]
public class DialogueScriptSnippet
{
    public string Kind { get; set; }
    public string Label { get; set; }
    public string Text { get; set; }
    public IEnumerable<string> Options { get; set; }
}
