using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private ISelection HighlightSelection;

    private Transform _selection;


    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        HighlightSelection = gameObject.GetComponent<ISelection>();
    }

    private void Update()
    {
        HighlightSelection.OnDeselect(_selection);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        HighlightSelection.OnSelect(_selection);
    }
}
