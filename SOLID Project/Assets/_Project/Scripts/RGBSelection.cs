using UnityEngine;

public class RGBSelection : MonoBehaviour, ISelection
{
    [SerializeField] private int strobeIntensity = 10;

    private Color baseColor;
    private Color currentColor;
    private Renderer selectedMeshRenderer;

    private static Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    public void OnDeselect(Transform _selection)
    {
        if (selectedMeshRenderer == null)
            return;
        selectedMeshRenderer.material.color = baseColor;
        selectedMeshRenderer = null;
    }

    public void OnSelect(Transform _selection)
    {
        if (_selection == null)
            return;
        selectedMeshRenderer = _selection.GetComponent<Renderer>();
        baseColor = selectedMeshRenderer.material.color;
        Color randomColor = GetRandomColor();
        currentColor = new Color(Mathf.Lerp(currentColor.r, randomColor.r, Time.deltaTime * strobeIntensity),
            Mathf.Lerp(currentColor.g, randomColor.g, Time.deltaTime * strobeIntensity),
            Mathf.Lerp(currentColor.b, randomColor.b, Time.deltaTime * strobeIntensity));
        Debug.Log("CurrentColor: " + currentColor.r + "," + currentColor.g + "," + currentColor.b + "," + currentColor.a);
        selectedMeshRenderer.material.color = currentColor;
    }
}
