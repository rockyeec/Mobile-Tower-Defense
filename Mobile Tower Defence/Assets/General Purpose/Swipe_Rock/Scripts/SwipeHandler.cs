using UnityEngine;

public enum SwipeDirection
{ 
    Up, Down, Left, Right
}

public class SwipeHandler : MonoBehaviour
{
    private Vector3 startPoint;
    private float time = 0.0f;
    [SerializeField] private float maxDuration = 0.25f;
    [SerializeField] private float minSqrMagnitude = 100000.0f;

    public static event System.Action<SwipeDirection> OnSwipe = delegate { };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouchDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchUp();
        }
    }

    private void OnTouchDown()
    {
        startPoint = Input.mousePosition;
        time = Time.time + maxDuration;
    }
    private void OnTouchUp()
    {
        if (Time.time > time)
        {
            return;
        }
        Vector3 direction = Input.mousePosition - startPoint;
        print(direction.sqrMagnitude);
        if (direction.sqrMagnitude < minSqrMagnitude)
        {
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            OnSwipe(direction.x > 0.0f ? SwipeDirection.Right : SwipeDirection.Left);
            //print(direction.x > 0.0f ? "Right" : "Left");
        }
        else
        {
            OnSwipe(direction.y > 0.0f ? SwipeDirection.Up : SwipeDirection.Down);
            //print(direction.y > 0.0f ? "Up" : "Down");
        }
    }
}
