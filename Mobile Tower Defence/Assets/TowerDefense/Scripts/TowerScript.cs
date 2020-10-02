using UnityEngine;

public class TowerScript : Deployable
{
    [Header("Tower Attributes")]
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private Transform gun = null;
    [SerializeField] private Transform turret = null;
    [SerializeField] private TowerStats stats = null;

    private ITowerAbility towerAbility = null;

    protected override void Init()
    {
        base.Init();

        towerAbility = GetComponent<ITowerAbility>();
    }

    protected override void Tick(in float delta)
    {
        base.Tick(delta);

        Collider[] colliders = Physics.OverlapSphere(turret.position, 16.9f, 1 << 10);
        if (colliders.Length != 0)
        {
            Collider nearest = colliders.GetNearest(transform);
            Vector3 direction = nearest.transform.position - turret.position;
            HandleTurretRotation(in delta, in direction);
            HandleGunRotation(in delta, in nearest);
            HandleFirepointRotation(in direction);
            Fire();
        }
    }
    private void HandleFirepointRotation(in Vector3 direction)
    {
        firePoint.rotation = Quaternion.LookRotation(direction);
    }
    private void HandleTurretRotation(in float delta, in Vector3 direction)
    {
        Vector3 turretDir = direction.With(y : 0.0f);
        Quaternion towerRot = Quaternion.LookRotation(turretDir);
        turret.rotation = Quaternion.Slerp(turret.rotation, towerRot, 6.9f * delta);
    }
    private void HandleGunRotation(in float delta, in Collider nearest)
    {
        Vector3 gunDir = nearest.transform.position - gun.position;
        Quaternion gunRot = Quaternion.LookRotation(gunDir).WithEuler(y: 0.0f);
        gun.localRotation = Quaternion.Slerp(gun.localRotation, gunRot, 6.9f * delta);
    }
    private void Fire()
    {
        if (towerAbility == null)
            return;

        if (Vector3.Dot(firePoint.forward, gun.forward) < 0.98f)
            return;
        
        towerAbility.Execute(in stats);
        
    }
}
