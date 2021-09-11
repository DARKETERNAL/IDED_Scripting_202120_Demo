using UnityEngine;

public class FactoryTurret : Turret
{
    private BulletFactory bulletFactory;
    private BulletPoolDecorator decorator;

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
            // ?:
            //OOPBullet bullet = null;
            //if (decorator == null)
            //{
            //    bullet = bulletFactory.GetBullet();
            //}
            //else
            //{
            //    bullet = decorator.GetBullet();
            //}

            OOPBullet bullet = decorator == null ? bulletFactory.GetBullet() : decorator.GetBullet();

            if (bullet != null)
            {
                bullet.BulletRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            }
        }
    }

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            decorator = gameObject.AddComponent<BulletPoolDecorator>();
        }

        base.Update();
    }
}