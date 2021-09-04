using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPool : MonoBehaviour
{
    [SerializeField]
    private OOPBullet baseBullet;

    [SerializeField]
    private int poolSize = 5;

    private List<OOPBullet> bulletCollection = new List<OOPBullet>();

    public OOPBullet GetBullet()
    {
        OOPBullet bullet = null;

        if (bulletCollection.Count > 0)
        {
            bullet = bulletCollection[0];
            bulletCollection.RemoveAt(0);
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate<OOPBullet>(baseBullet);
        }

        return bullet;
    }

    public void StoreBullet(OOPBullet targetBullet)
    {
        bulletCollection.Add(targetBullet);
        targetBullet.BulletRigidbody.velocity = Vector3.zero;
        targetBullet.gameObject.SetActive(false);
        targetBullet.transform.position = transform.position;
    }

    private void Awake()
    {
        if (baseBullet != null)
        {
            for (int i = 0; i < poolSize; i++)
            {
                OOPBullet bulletInstance = Instantiate<OOPBullet>(baseBullet);
                StoreBullet(bulletInstance);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            OOPBullet[] allBullets = FindObjectsOfType<OOPBullet>();

            for (int i = 0; i < allBullets.Length; i++)
            {
                StoreBullet(allBullets[i]);
            }
        }
    }
}