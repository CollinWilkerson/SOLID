using UnityEngine;
using System.Collections.Generic;

public class CompositeSelectionResponse : MonoBehaviour, ISelection
{
    [SerializeField] private GameObject selectionResponseObject;

    private ISelection[] selectionResponses;
    private Transform currentSelection;
    private int currentIndex;

    private void Start()
    {
        selectionResponses = selectionResponseObject.GetComponents<ISelection>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SelectNextResponse();
        }
    }

    public void OnDeselect(Transform _selection)
    {
        if (!HasSelection())
        {
            return;
        }
        selectionResponses[currentIndex].OnDeselect(_selection);
    }

    public void OnSelect(Transform _selection)
    {
        if (!HasSelection())
        {
            return;
        }
        currentSelection = _selection;
        selectionResponses[currentIndex].OnSelect(_selection);
    }

    private bool HasSelection()
    {
        return currentIndex > -1 && currentIndex < selectionResponses.Length;
    }

    [ContextMenu("NextResponse")]
    public void SelectNextResponse()
    {
        selectionResponses[currentIndex].OnDeselect(currentSelection);
        currentIndex = (currentIndex + 1) % selectionResponses.Length;
        Debug.Log("switch to " + selectionResponses[currentIndex]);
        selectionResponses[currentIndex].OnSelect(currentSelection);
    }
}
