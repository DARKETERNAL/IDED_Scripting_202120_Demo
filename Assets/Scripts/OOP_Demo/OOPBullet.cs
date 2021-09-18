using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class OOPBullet : MonoBehaviour
{
    public delegate void OnBulletReadyToDispose(OOPBullet bullet);

    public OnBulletReadyToDispose onBulletReadyToDispose;

    public abstract EBulletType BulletType { get; }

    public bool CanBeRecycled { get; private set; }

    public Rigidbody BulletRigidbody { get; private set; }

    private BulletPool pool;

    public void SetCanBeRecycled()
    {
        CanBeRecycled = true;
    }

    private void Awake()
    {
        BulletRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke("DisposeBullet", 5F);
    }

    private void OnDisable()
    {
        CancelInvoke("DisposeBullet");
    }

    private void DisposeBullet()
    {
        if (onBulletReadyToDispose != null)
        {
            onBulletReadyToDispose(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}