using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class OOPBullet : MonoBehaviour
{
    public abstract EBulletType BulletType { get; }

    public Rigidbody BulletRigidbody { get; private set; }

    private void Awake()
    {
        BulletRigidbody = GetComponent<Rigidbody>();
    }
}