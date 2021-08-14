using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected string impactMessage;

    private void OnCollisionEnter(Collision collision)
    {
        print(impactMessage);
        Destroy(gameObject);
    }
}
