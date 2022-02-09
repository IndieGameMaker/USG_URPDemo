using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private Camera camera;

    // Ray, RaycastHit
    private Ray ray;
    private RaycastHit hit;

    private int hashForward = Animator.StringToHash("Forward");

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        camera = Camera.main;
    }

    void Update()
    {
        // 스크린의 2차원 좌표(x,y) -> 3D 투영하는 광선을 생성
        ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f, 1 << 8))
            {
                agent.SetDestination(hit.point);
                //anim.SetFloat("Forward", 1.0f); Hashtable을 거치는 방식
            }
        }
    }
}
