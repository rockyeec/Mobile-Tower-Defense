using UnityEngine;

[CreateAssetMenu(menuName = "Tower Stats")]
public class TowerStats : ScriptableObject
{
    [SerializeField] private float interval = 0.4f;
    [SerializeField] private float range = 13.37f;
    [SerializeField] private float power = 1.0f;

    public float Interval { get { return interval; } }
    public float Range { get { return range; } }
    public float Power { get { return power; } }
}
