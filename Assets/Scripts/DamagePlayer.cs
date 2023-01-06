using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField ]int Damage;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject != null)
        {
            if (col.gameObject.GetComponent<LiveController>()) { col.gameObject.GetComponent<LiveController>().TakeDamage(Damage); }
        }
    }
}
