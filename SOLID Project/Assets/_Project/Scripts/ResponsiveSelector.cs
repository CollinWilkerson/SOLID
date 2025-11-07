using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private float threshould = 0.99f;
    [SerializeField] private SelectableObject[] selectables;
    private Transform selection;

    private void Start()
    {
        selectables = FindObjectsByType<SelectableObject>(FindObjectsSortMode.None);
    }

    public Transform GetSelection()
    {
        return selection;
    }

    public Transform SelectTaggedObject(Ray ray, string selectableTag)
    {
        selection = null;

        float closest = 0;
        foreach (SelectableObject t in selectables)
        {
            var vector1 = ray.direction;
            var vector2 = t.transform.position - ray.origin;

            float lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            t.SetText(lookPercentage.ToString("F3"));

            if(lookPercentage > threshould && lookPercentage > closest)
            {
                closest = lookPercentage;
                selection = t.transform; 
            }
        }
        return selection;
    }
}
