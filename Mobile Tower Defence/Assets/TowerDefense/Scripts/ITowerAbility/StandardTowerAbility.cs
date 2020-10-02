using UnityEngine;

public class StandardTowerAbility : MonoBehaviour, ITowerAbility
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform firePoint = null;
    
    private float time = 0.0f;

    public void Execute(in TowerStats stats)
    {
        if (time.IsNextInterval(stats.Interval))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
