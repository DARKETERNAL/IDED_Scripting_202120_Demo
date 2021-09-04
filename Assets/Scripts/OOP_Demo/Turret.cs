using UnityEngine;

public class Turret : MonoBehaviour
{
    public static bool isDelayed;

    protected float delayTime = 0.65F;

    [SerializeField]
    protected EBulletType bulletType;

    [SerializeField]
    protected float shootTime = 2F;

    [SerializeField]
    protected float speed = 10F;

    [SerializeField]
    private Transform spawnPosition;

    [Header("Bullets")]
    [SerializeField]
    private LowBullet lowBulletPrefab;

    [SerializeField]
    private MidBullet midBulletPrefab;

    [SerializeField]
    private HardBullet hardBulletPrefab;

    // Start is called before the first frame update
    protected void Start()
    {
        InvokeRepeating("Shoot", 0F, shootTime);
    }

    private void Shoot()
    {
        SpawnBullet();
    }

    protected virtual void SpawnBullet()
    {
        OOPBullet bullet = null;

        switch (bulletType)
        {
            case EBulletType.Low:
                bullet = Instantiate<LowBullet>(lowBulletPrefab, spawnPosition.position, spawnPosition.rotation);
                break;

            case EBulletType.Mid:
                bullet = Instantiate<MidBullet>(midBulletPrefab, spawnPosition.position, spawnPosition.rotation);
                break;

            case EBulletType.Hard:
                bullet = Instantiate<HardBullet>(hardBulletPrefab, spawnPosition.position, spawnPosition.rotation);
                break;
        }

        if (bullet != null)
        {
            bullet.BulletRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }

    protected void Update()
    {
        if (isDelayed)
        {
            DelayTurrets();
            isDelayed = false;
        }
    }

    public void DelayTurrets()
    {
        CancelInvoke("Shoot");
        shootTime *= 1 + delayTime;
        InvokeRepeating("Shoot", shootTime, shootTime);
    }
}