using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    public float scrollSpeed = 4.0f;
    private float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, Mathf.Abs(startPosition * 2));
        transform.position = new Vector2(startPosition - newPosition, transform.position.y);
    }
}