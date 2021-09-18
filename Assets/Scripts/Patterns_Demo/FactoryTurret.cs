using System;
using UnityEngine;

public class FactoryTurret : Turret
{
    private BulletFactory bulletFactory;
    private BulletPoolDecorator decorator;

    public Action<EBulletType> OnBulletTypeChanged;

    private void Awake()
    {
        bulletFactory = GetComponent<BulletFactory>();
    }

    protected override void Start()
    {
        shootCommand = gameObject.AddComponent<FactoryShootCommand>();
        (shootCommand as FactoryShootCommand).Subscribe(this);
        shootCommand.Init(bulletType, spawnPosition, speed);
    }

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            bulletType = EBulletType.Low;

            if (OnBulletTypeChanged != null)
            {
                OnBulletTypeChanged(bulletType);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            bulletType = EBulletType.Mid;

            if (OnBulletTypeChanged != null)
            {
                OnBulletTypeChanged(bulletType);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            bulletType = EBulletType.Hard;

            if (OnBulletTypeChanged != null)
            {
                OnBulletTypeChanged(bulletType);
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            decorator = gameObject.AddComponent<BulletPoolDecorator>();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }
    }
}