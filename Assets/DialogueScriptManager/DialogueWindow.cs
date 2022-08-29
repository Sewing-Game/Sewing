using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    private TextMeshProUGUI _dialogue = null;
    private UnityEngine.UI.Image _background = null;

    private void Awake()
    {
        _dialogue = GetComponentInChildren<TextMeshProUGUI>();
        _background = GetComponentInChildren<UnityEngine.UI.Image>();
        Hide();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        Show(_dialogue);
        Show(_background);
    }

    private void Show(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(true);
        monoBehaviour.enabled = true;     
    }

    public void Hide()
    {
        Hide(_dialogue);
        Hide(_background);
    }

    private void Hide(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(false);
        monoBehaviour.enabled = false;
    }

    public string Text { get => _dialogue.text; set => _dialogue.text = value; }
}
