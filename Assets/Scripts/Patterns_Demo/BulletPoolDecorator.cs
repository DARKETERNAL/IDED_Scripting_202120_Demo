using UnityEngine;

public class BulletPoolDecorator : MonoBehaviour, IBulletPool
{
    private int maxAmmo = 5;
    private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    public OOPBullet GetBullet()
    {
        OOPBullet bullet = null;
        OOPBullet bulletGO = Resources.Load<OOPBullet>("HardBullet");

        if (bulletGO != null)
        {
            bullet = Instantiate(bulletGO);
            currentAmmo -= 1;
        }

        if (currentAmmo == 0)
        {
            Destroy(this);
        }

        return bullet;
    }
}