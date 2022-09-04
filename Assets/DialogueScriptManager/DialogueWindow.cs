using System.Runtime.ConstrainedExecution;
using System.Text;
using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    [Range(0.001f, 10f)]
    public float displaySpeed = 0.1f;
    private float LettersPerSecond => displaySpeed != 0 ? 1 / displaySpeed : float.MaxValue;

    private TextMeshProUGUI _dialogue = null;
    private UnityEngine.UI.Image _background = null;
    private int _displayedCursor = 0;
    private float _displayedStartTime = 0f;

    private object _cursorLock = new object();


    public int DisplayedCursor
    {
        get => _displayedCursor;
        set
        {
            _displayedCursor = Mathf.Min(value, Text.Length);
            if (_displayedCursor <= Text.Length)
            {
                DisplayedText = Text[.._displayedCursor];
            }
        }
    }

    public bool TextDisplayed => Text == DisplayedText;


    public string _text;
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _displayedCursor = 0;
            _displayedStartTime = Time.unscaledTime;
        }
    }

    public string DisplayedText
    {
        get => _dialogue.text;
        set => _dialogue.text = value;
    }

    private void Awake()
    {
        _dialogue = GetComponentInChildren<TextMeshProUGUI>();
        _background = GetComponentInChildren<UnityEngine.UI.Image>();
        WindowHide();
    }

    // Update is called once per frame
    void Update()
    {
        lock (_cursorLock)
        {
            if (DisplayedCursor < Text.Length)
            {
                DisplayedCursor = (int)Mathf.Ceil((Time.unscaledTime - _displayedStartTime) * LettersPerSecond);
            }
        }

    }

    public void WindowShow()
    {
        PrefabShow(_dialogue);
        PrefabShow(_background);
    }

    private void PrefabShow(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(true);
        monoBehaviour.enabled = true;
    }

    public void WindowHide()
    {
        Hide(_dialogue);
        Hide(_background);
    }

    private void Hide(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(false);
        monoBehaviour.enabled = false;
    }

    public void Skip()
    {
        lock (_cursorLock)
        {
            DisplayedCursor = Text.Length;
        }
    }
}
