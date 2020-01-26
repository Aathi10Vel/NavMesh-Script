using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavControl : MonoBehaviour
{
    public ThirdPersonControl crypto_NavCharacter;
    public Camera navCamera;
    public NavMeshAgent crypto_NavAgent;
    Ray crypto_NavRay;
    RaycastHit crypto_NavHitRay;

    // Start is called before the first frame update
    void Start()
    {
        crypto_NavAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        NavMovePlayer();
    }

    public void NavMovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            crypto_NavRay = navCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(crypto_NavRay,out crypto_NavHitRay))
            {
                crypto_NavAgent.SetDestination(crypto_NavHitRay.point);
            }
        }

        if (crypto_NavAgent.remainingDistance > crypto_NavAgent.stoppingDistance)
        {
            crypto_NavCharacter.Crypto_Move(crypto_NavAgent.desiredVelocity);
        }
        else
        {
            crypto_NavCharacter.Crypto_Move(Vector3.zero);
        }
    }
}
