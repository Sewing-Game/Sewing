using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [Range(0.001f, 10f)]
    public float displaySpeed = 0.1f;
    private float LettersPerSecond => displaySpeed != 0 ? 1 / displaySpeed : float.MaxValue;

    private int _displayedCursor = 0;
    private float _displayedStartTime = 0f;

    private readonly object _cursorLock = new();
    public DialogueWindow _dialogueWindow = null;
    public LabelWindow _labelWindow = null;

    public int DisplayedCursor
    {
        get => _displayedCursor;
        set
        {
            _displayedCursor = Mathf.Min(value, DialogueText.Length);
            if (_displayedCursor <= DialogueText.Length)
            {
                DisplayedDialogueText = DialogueText[.._displayedCursor];
            }
        }
    }

    public bool TextDisplayed => DialogueText == DisplayedDialogueText;

    public string _dialogueText;
    public string DialogueText
    {
        get => _dialogueText;
        set
        {
            _dialogueText = value;
            _displayedCursor = 0;
            _displayedStartTime = Time.unscaledTime;
        }
    }

    public string DisplayedDialogueText
    {
        get => _dialogueWindow.Text;
        set => _dialogueWindow.Text = value;
    }

    public string LabelText
    {
        get => _labelWindow.Text;
        set => _labelWindow.Text = value;
    }

    private void Awake()
    {
        _dialogueWindow = GetComponentInChildren<DialogueWindow>();
        _labelWindow = GetComponentInChildren<LabelWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        lock (_cursorLock)
        {
            if (DisplayedCursor < DialogueText.Length)
            {
                DisplayedCursor = (int)Mathf.Ceil((Time.unscaledTime - _displayedStartTime) * LettersPerSecond);
            }
        }

    }

    public void WindowShow()
    {
        _dialogueWindow.Show();
        _labelWindow.Show();
    }

    public void WindowHide()
    {
        _dialogueWindow.Hide();
        _labelWindow.Hide();
    }

    public void Skip()
    {
        lock (_cursorLock)
        {
            DisplayedCursor = DialogueText.Length;
        }
    }
}
