using UnityEngine;

public class ScreenRayProvider : MonoBehaviour, IRayProvider
{
    public Ray GetRay()
    {
        //more stable because we use the center of the canvas
        return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
