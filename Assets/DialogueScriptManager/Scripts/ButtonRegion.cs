using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonRegion : MonoBehaviour
{
    public DialogueButton buttonPrefeb;

    private List<DialogueButton> _buttons = new();
    public IEnumerable<DialogueButton> Buttons => _buttons.AsEnumerable();

    public void Clear()
    {
        foreach (var item in _buttons)
        {
            Destroy(item.gameObject);
        }

        _buttons.Clear();
    }

    public void AddButton(string text)
    {
        var button = Instantiate(buttonPrefeb);
        button.Text = text;
        AddButton(button);

    }

    public void AddButtons(IEnumerable<string> text)
    {
        foreach (var item in text)
        {
            AddButton(item);
        }
    }

    public void AddButton(DialogueButton button)
    {
        var buttonTransform = button.GetComponent<RectTransform>();
        if (buttonTransform.parent != transform)
        {
            buttonTransform.SetParent(transform);
        }
        var totalWidth = _buttons.Select(item => item.GetComponent<RectTransform>().sizeDelta.x).Sum();
        buttonTransform.localPosition = new Vector3(totalWidth, 0, transform.position.z);
        _buttons.Add(button);        
    }

    public void Show()
    {
        DialogueHelper.PrefabShow(this);
    }

    public void Hide()
    {
        DialogueHelper.PrefabHide(this);
    }
}
