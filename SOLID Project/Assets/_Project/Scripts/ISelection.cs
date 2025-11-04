using UnityEngine;

public interface ISelection
{
    public void OnDeselect(Transform _selection);
    public void OnSelect(Transform _selection);
}