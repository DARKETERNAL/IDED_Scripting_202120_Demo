using UnityEngine;

public class FactoryShootCommand : ShootCommand
{
    private BulletPoolDecorator decorator;
    private BulletPool bulletFactory;

    private void Start()
    {
        bulletFactory = GetComponent<BulletPool>();
    }

    protected override void SpawnBullet()
    {
        decorator = GetComponent<BulletPoolDecorator>();

        OOPBullet bullet = decorator == null ? bulletFactory.GetBullet() : decorator.GetBullet();

        if (bullet != null)
        {
            bullet.BulletRigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
        }
    }
}