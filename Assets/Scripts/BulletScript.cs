using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject ImpactEffect;
    public float damage;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject != null)
        {
            Destroy(gameObject);
        }

    }
}
