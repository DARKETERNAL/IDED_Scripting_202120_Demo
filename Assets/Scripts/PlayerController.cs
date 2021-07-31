using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody[] bulletTypes;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float bulletSpeed = 10F;
    
    private int currentTypeIndex; // = 0    

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody currentBullet = bulletTypes[currentTypeIndex];  // Choose bullet
            Rigidbody currentBulletInstance = Instantiate<Rigidbody>(currentBullet, spawnPoint.position, spawnPoint.rotation); // Instantiate bullet
            currentBulletInstance.AddForce(Vector3.right * bulletSpeed, ForceMode.Impulse); // Shoot bullet

            //Instantiate<Rigidbody>(
            //    bulletTypes[currentTypeIndex], spawnPoint.position, spawnPoint.rotation)
            //    .AddForce(Vector3.right * bulletSpeed, ForceMode.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            currentTypeIndex = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            currentTypeIndex = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            currentTypeIndex = 2;
        }
    }
}