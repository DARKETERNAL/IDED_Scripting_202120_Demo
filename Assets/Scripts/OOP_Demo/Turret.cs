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
    protected Transform spawnPosition;

    protected ShootCommand shootCommand;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        InvokeRepeating("Shoot", 0F, shootTime);
        shootCommand = gameObject.AddComponent<ShootCommand>();
        shootCommand.Init(bulletType, spawnPosition, speed);
    }

    protected void Shoot()
    {
        shootCommand.Execute();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            isDelayed = true;
        }

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