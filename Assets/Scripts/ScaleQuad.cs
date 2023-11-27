using UnityEngine;

public class ScaleQuad : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private void Start () {
        
        var height = mainCam.orthographicSize * 2;
        var width = mainCam.orthographicSize * 2 * Screen.width / Screen.height;
 
        transform.localScale = new Vector3(width+0.25f, height+0.25f, 1);
 
    }

}
