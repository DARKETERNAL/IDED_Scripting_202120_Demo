using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    private const string message = "HelloWorld";

    private List<int> list = new List<int>();

    [SerializeField]
    private int iterations = 10000;

    [SerializeField]
    private float speed = 10F;

    [SerializeField]
    private float force = 100F;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        //InvokeRepeating("PrintMessage", 0F, 0.2F);
        rb = GetComponent<Rigidbody>();
    }

    private void PrintMessage()
    {
        print(message);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Bounce"))
    //    {
    //        GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
    //        Debug.Break();
    //    }
    //}

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        for (int i = 0; i < iterations; i++)
        {
            list.Add(0);
        }

        rb.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Impulse);
    }
}