using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static T GetRandom<T>(this T[] items)
    {
        return items[Random.Range(0, items.Length)];
    }

    public static T GetRandom<T>(this List<T> items)
    {
        return items[Random.Range(0, items.Count)];
    }

    public static Collider GetNearest(this Collider[] colliders, Transform transform)
    {
        return colliders.OrderBy(t => (transform.position - t.transform.position).sqrMagnitude).FirstOrDefault();
    }

    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }

    public static Quaternion WithEuler(this Quaternion original, float? x = null, float? y = null, float? z = null)
    {
        Vector3 originalEuler = original.eulerAngles;
        return Quaternion.Euler(
            originalEuler.With(
                x ?? originalEuler.x,
                y ?? originalEuler.y,
                z ?? originalEuler.z)
            );
    }

    public static bool IsNextInterval(this ref float time, in float intervalDuration)
    {
        if (Time.time >= time)
        {
            time = Time.time + intervalDuration;
            return true;
        }
        return false;
    }

    public static bool IsWithinInterval(this ref float elapsed, in float duration, in float deltaTime)
    {
        if (elapsed < duration)
        {
            elapsed += deltaTime;
            return true;
        }
        return false;
    }
}
