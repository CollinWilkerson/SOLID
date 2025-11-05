using UnityEngine;

public interface ISelector
{
    Transform GetSelection();
    Transform SelectTaggedObject(Ray ray, string selectableTag);
}