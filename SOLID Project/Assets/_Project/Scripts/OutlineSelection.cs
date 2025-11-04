using UnityEngine;

public class OutlineSelection : MonoBehaviour, ISelection
{
    public void OnDeselect(Transform _selection)
    {
        if (_selection == null)
            return;

        Outline outline = _selection.GetComponent<Outline>();
        if (outline == null)
        {
            return;
        }
        outline.OutlineWidth = 0;
    }

    public void OnSelect(Transform _selection)
    {
        if (_selection == null)
            return;

        Outline outline = _selection.GetComponent<Outline>();
        if (outline == null)
        {
            return;
        }
        outline.OutlineWidth = 10;
    }
}
