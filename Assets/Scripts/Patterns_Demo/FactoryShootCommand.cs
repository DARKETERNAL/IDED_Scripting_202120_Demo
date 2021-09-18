using UnityEngine;

public class FactoryShootCommand : ShootCommand
{
    private EBulletType bulletType;
    private BulletFacade bulletFactoryFacade;

    public void Subscribe(FactoryTurret turret)
    {
        turret.OnBulletTypeChanged += OnBulletTypeChanged;
    }

    private void OnBulletTypeChanged(EBulletType newBulletType)
    {
        bulletType = newBulletType;
    }

    private void Start()
    {
        bulletFactoryFacade = GetComponent<BulletFacade>();
    }

    protected override void SpawnBullet()
    {
        OOPBullet bullet = bulletFactoryFacade.GetBullet(bulletType);

        if (bullet != null)
        {
            bullet.BulletRigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
        }
    }
}