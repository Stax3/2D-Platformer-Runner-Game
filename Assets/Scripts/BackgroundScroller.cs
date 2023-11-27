using System.Collections;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer _renderer;
    private Vector2 _savedOffset;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    private void Start () 
    {
        _renderer = GetComponent<Renderer> ();
    }

    private void Update () 
    {
        var scrolldirection = Mathf.Repeat (Time.time * scrollSpeed, 1);
        var offset = new Vector2 (scrolldirection, 0);
        
        _renderer.sharedMaterial.SetTextureOffset(MainTex, offset);
    }

    public void UpdateSpeed(float value)
    {
        StartCoroutine(ChangeSpeed(value));
    }

    private IEnumerator ChangeSpeed(float value)
    {
        while (scrollSpeed >= value)
        {
            scrollSpeed += 0.02f;
            yield return null;
        }
    }
}