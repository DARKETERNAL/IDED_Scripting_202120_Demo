using UnityEngine;

public class FactoryTurret : Turret
{
    private BulletFactory bulletFactory;
    private BulletPoolDecorator decorator;

    private void Awake()
    {
        bulletFactory = GetComponent<BulletFactory>();
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", 0F, shootTime);
        shootCommand = gameObject.AddComponent<FactoryShootCommand>();
        shootCommand.Init(bulletType, spawnPosition, speed);
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