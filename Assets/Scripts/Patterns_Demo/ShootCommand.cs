using UnityEngine;

public class ShootCommand : MonoBehaviour, ICommand
{
    protected EBulletType BulletType { get; set; }
    protected Transform SpawnPosition { get; set; }
    protected float Speed { get; set; }

    private LowBullet lowBulletPrefab;
    private MidBullet midBulletPrefab;
    private HardBullet hardBulletPrefab;

    public void Init(EBulletType bulletType, Transform spawnPosition, float speed)
    {
        BulletType = bulletType;
        SpawnPosition = spawnPosition;
        Speed = speed;
    }

    public void Execute()
    {
        if (lowBulletPrefab == null)
        {
            lowBulletPrefab = Resources.Load<LowBullet>("LowBullet");
        }

        if (midBulletPrefab == null)
        {
            midBulletPrefab = Resources.Load<MidBullet>("MidBullet");
        }

        if (hardBulletPrefab == null)
        {
            hardBulletPrefab = Resources.Load<HardBullet>("HardBullet");
        }

        SpawnBullet();
    }

    protected virtual void SpawnBullet()
    {
        OOPBullet bullet = null;

        switch (BulletType)
        {
            case EBulletType.Low:
                bullet = Instantiate(lowBulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
                break;

            case EBulletType.Mid:
                bullet = Instantiate(midBulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
                break;

            case EBulletType.Hard:
                bullet = Instantiate(hardBulletPrefab, SpawnPosition.position, SpawnPosition.rotation);
                break;
        }

        if (bullet != null)
        {
            bullet.BulletRigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
        }
    }
}