using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [Header("Bullets")]
    [SerializeField]
    private LowBullet lowBulletPrefab;

    [SerializeField]
    private MidBullet midBulletPrefab;

    [SerializeField]
    private HardBullet hardBulletPrefab;

    public OOPBullet GetBullet(EBulletType bulletType)
    {
        OOPBullet bullet = null;

        switch (bulletType)
        {
            case EBulletType.Low:
                bullet = Instantiate<LowBullet>(lowBulletPrefab, transform);
                break;

            case EBulletType.Mid:
                bullet = Instantiate<MidBullet>(midBulletPrefab, transform);
                break;

            case EBulletType.Hard:
                bullet = Instantiate<HardBullet>(hardBulletPrefab, transform);
                break;
        }

        return bullet;
    }
}