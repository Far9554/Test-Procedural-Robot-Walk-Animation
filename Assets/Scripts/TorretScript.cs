using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretScript : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Transform ShotPosition;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Rotator;
    [Range(0.1f,10f)] public float fireRate=0.1f;
    [SerializeField] bool CanShoot = true;
    public float spread = 2;

    // Update is called once per frame
    void Update()
    {
        Attack();
        //RaycastHit hit;
        //if (Physics.Raycast(ShotPosition.transform.position, Target.position, out hit))
        //{
        //    if (hit.collider.tag == "Player") { Attack(); Debug.Log("Ataking"); }
        //    Debug.DrawLine(ShotPosition.transform.position, Target.position);
        //}
    }

    void Attack()
    {
        if (CanShoot)
        {
            InvokeRepeating("Shoot", 0.1f, fireRate);
            Invoke("StopShoot", 3f);
            CanShoot = false;
        }
    }

    void Shoot()
    {
        //Generar Rotacion Aleatoria
        float rotX = Random.Range(-spread, spread);
        float rotY = Random.Range(-spread, spread);

        //Debug.Log(rotX + "," + rotY);

        ShotPosition.transform.Rotate(rotX, rotY, 0f);

        GameObject bala = Instantiate(Bullet, ShotPosition.position, ShotPosition.rotation);
        Rigidbody rb1 = bala.GetComponent<Rigidbody>();
        rb1.AddForce(ShotPosition.transform.forward * 2000);
        Destroy(bala, 2f);

        ShotPosition.transform.Rotate(-rotX, -rotY, 0f);

        if (Rotator != null) { Rotator.transform.Rotate(5 * Vector3.forward, Space.Self); }
    }

    void StopShoot()
    {
        CancelInvoke("Shoot");
        CanShoot = true;
    }
}
