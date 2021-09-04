using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private BulletPool bulletPool;

    private void Awake()
    {
        bulletPool = GetComponent<BulletPool>();
    }

    public OOPBullet GetBullet()
    {
        OOPBullet bullet = null;

        if (bulletPool != null)
        {
            bullet = bulletPool.GetBullet();
        }

        return bullet;
    }
}