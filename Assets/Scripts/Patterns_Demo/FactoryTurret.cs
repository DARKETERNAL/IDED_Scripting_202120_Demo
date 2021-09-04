using UnityEngine;

public class FactoryTurret : Turret
{
    private BulletFactory bulletFactory;

    private void Awake()
    {
        bulletFactory = GetComponent<BulletFactory>();
    }

    protected override void SpawnBullet()
    {
        if (bulletFactory == null)
        {
            CancelInvoke("Shoot");
        }
        else
        {
            OOPBullet bullet = bulletFactory.GetBullet(bulletType);

            if (bullet != null)
            {
                bullet.BulletRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            }
        }
    }
}