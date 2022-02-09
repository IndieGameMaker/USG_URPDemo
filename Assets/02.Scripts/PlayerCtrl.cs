using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    private NavMeshAgent agent;

    private Camera camera;

    // Ray, RaycastHit
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        camera = Camera.main;
    }

    void Update()
    {
        // 스크린의 2차원 좌표(x,y) -> 3D 투영하는 광선을 생성
        ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);
    }
}
