using UnityEngine;

public static class DialogueHelper
{
    public static void PrefabShow(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(true);
        monoBehaviour.enabled = true;
    }

    public static void PrefabHide(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.gameObject.SetActive(false);
        monoBehaviour.enabled = false;
    }
}
