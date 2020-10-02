using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float flightDuration = 0.5f;
    private Vector3 originalPos;
    private Vector3 targetPos;
    private float time = 0.0f;
    private void OnEnable()
    {
        time = 0.0f;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            originalPos = transform.position;
            targetPos = hit.point;
            flightDuration *= (hit.distance / 100.0f);
        }
        else
        {
            KillSelf();
        }
    }

    private void Update()
    {
        if (time.IsWithinInterval(flightDuration, Time.deltaTime))
        {
            float t = time / flightDuration;

            transform.position = Vector3.Lerp(originalPos, targetPos, t);

            return;
        }

        KillSelf();
    }

    private void KillSelf()
    {
        Destroy(gameObject);
    }
}
