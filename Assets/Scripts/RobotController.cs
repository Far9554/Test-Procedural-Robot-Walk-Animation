using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    [SerializeField] Transform Cabeza;

    [SerializeField] Transform FootLeft;
    [SerializeField] Transform FootRight;
    [SerializeField] Vector3 Offset;
    [SerializeField] Vector3 targetPos;

    [SerializeField] Transform FingersLeft;
    [SerializeField] Transform FingersRight;

    [SerializeField] NavMeshAgent IA;
    [SerializeField] Transform Player;
    [SerializeField] GameObject Particle;

    bool CanPartLeft = false;
    bool CanPartRight = false;

    // Start is called before the first frame update
    void Start()
    {
        Offset = Cabeza.transform.localPosition;
        if (IA == null) { IA.GetComponent<NavMeshAgent>(); }
    }

    // Update is called once per frame
    void Update()
    {
        IA.SetDestination(Player.position + new Vector3(0,1,0));

        targetPos = transform.position;
        targetPos.y += ((FootLeft.localPosition.y + FootRight.localPosition.y) / 2) + Offset.y;
        //Cabeza.transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.5f * Time.deltaTime);

        if (FootLeft.GetComponent<IKFootSolver>().IsMoving()) { FingersLeft.Rotate(1 * Vector3.left, Space.Self); CanPartLeft = true; }
        if (FootRight.GetComponent<IKFootSolver>().IsMoving()) { FingersRight.Rotate(1 * Vector3.left, Space.Self); CanPartRight = true; }

        if (CanPartLeft && !FootLeft.GetComponent<IKFootSolver>().IsMoving()) { CanPartLeft = false; FootParticle(true); }
        if (CanPartRight && !FootRight.GetComponent<IKFootSolver>().IsMoving()) { CanPartRight = false; FootParticle(false); }
    }

    void FootParticle(bool LeftFoot)
    {
        if (LeftFoot)
        {
            GameObject Parti = Instantiate(Particle, FingersLeft.position, FingersLeft.rotation);
            Destroy(Parti,5);
        } 
        else
        {
            GameObject Parti = Instantiate(Particle, FingersRight.position, FingersRight.rotation);
            Destroy(Parti,5);
        }
    }
}
