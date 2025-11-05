using UnityEngine;
using TMPro;

public class SelectableObject : MonoBehaviour
{
    private TextMeshProUGUI textBox;

    private void Start()
    {
        textBox = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        textBox.text = text;
    }
}
