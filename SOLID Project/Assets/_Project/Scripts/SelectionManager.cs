using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    private ISelection HighlightSelection;
    private IRayProvider rayProvider;
    private ISelector selector;

    private Transform curSelection;


    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        HighlightSelection = gameObject.GetComponent<ISelection>();
        rayProvider = gameObject.GetComponent<IRayProvider>();
        selector = gameObject.GetComponent<ISelector>();
    }

    private void Update()
    {
        if (HighlightSelection == null)
        {
            Debug.Log("NO HIGHLIGHT SELECTION");
            return;
        }
        HighlightSelection.OnDeselect(curSelection);

        var ray = rayProvider.GetRay();

        curSelection = selector.SelectTaggedObject(ray, selectableTag);
        
        HighlightSelection.OnSelect(curSelection);
    }
}
