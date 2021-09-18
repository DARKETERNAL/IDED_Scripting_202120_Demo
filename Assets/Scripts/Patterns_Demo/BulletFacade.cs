using UnityEngine;

[RequireComponent(typeof(LowBulletPool))]
[RequireComponent(typeof(MidBulletPool))]
[RequireComponent(typeof(HardBulletPool))]
public class BulletFacade : MonoBehaviour
{
    private LowBulletPool lowBulletPool;
    private MidBulletPool midBulletPool;
    private HardBulletPool hardBulletPool;

    private void Start()
    {
        lowBulletPool = GetComponent<LowBulletPool>();
        midBulletPool = GetComponent<MidBulletPool>();
        hardBulletPool = GetComponent<HardBulletPool>();
    }

    public OOPBullet GetBullet(EBulletType bulletType)
    {
        OOPBullet bullet = null;

        switch (bulletType)
        {
            case EBulletType.Low:
                bullet = lowBulletPool.GetBullet();
                break;

            case EBulletType.Mid:
                bullet = midBulletPool.GetBullet();
                break;

            case EBulletType.Hard:
                bullet = hardBulletPool.GetBullet();
                break;
        }

        return bullet;
    }
}