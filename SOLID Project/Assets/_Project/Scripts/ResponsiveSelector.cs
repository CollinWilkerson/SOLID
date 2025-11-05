using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private float threshould;
    [SerializeField] private Transform[] selectables;
    private Transform selection;

    public Transform GetSelection()
    {
        return selection;
    }

    public Transform SelectTaggedObject(Ray ray, string selectableTag)
    {
        selection = null;

        foreach (Transform t in selectables)
        {
            var vector1 = ray.direction;
            var vector2 = t.position - ray.origin;

            float lookPercentage = Vector3.Dot(vector1, vector2);
        }
        return selection;
    }
}
