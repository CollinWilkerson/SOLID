using UnityEngine;

public class HighlightSelection : MonoBehaviour, ISelection
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    public void OnDeselect(Transform _selection)
    {
        if (_selection == null)
            return;

        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
        }

    }

    public void OnSelect(Transform _selection)
    {
        if (_selection == null)
            return;
        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }
    }
}