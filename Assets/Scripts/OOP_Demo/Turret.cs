using UnityEngine;

public class Turret : MonoBehaviour
{
    public static bool isDelayed;

    protected float delayTime = 0.65F;

    [SerializeField]
    private EBulletType bulletType;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private float shootTime = 2F;

    [SerializeField]
    private float speed = 10F;

    [Header("Bullets")]
    [SerializeField]
    private LowBullet lowBulletPrefab;

    [SerializeField]
    private MidBullet midBulletPrefab;

    [SerializeField]
    private HardBullet hardBulletPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Shoot", 0F, shootTime);
    }

    private void Shoot()
    {
        SpawnBullet();
    }

    private void SpawnBullet()
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

    private void Update()
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