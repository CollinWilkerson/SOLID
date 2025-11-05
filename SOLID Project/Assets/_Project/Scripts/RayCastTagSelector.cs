using UnityEngine;

public class RayCastTagSelector : MonoBehaviour, ISelector
{
    private Transform selection;

    public Transform GetSelection()
    {
        return selection;
    }

    public Transform SelectTaggedObject(Ray ray, string selectableTag)
    {
        selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            Transform _selection = hit.transform;
            if (_selection.CompareTag(selectableTag))
            {
                selection = _selection;
                //Debug.Log("Selected Object");
            }
        }
        return selection;
    }
}
