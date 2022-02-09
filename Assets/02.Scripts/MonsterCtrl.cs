using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform targetTr;

    private WaitForSeconds ws;
    public bool isDie = false;

    void Start()
    {
        ws = new WaitForSeconds(0.3f);
        targetTr = GameObject.FindGameObjectWithTag("PLAYER")?.transform;
        agent = GetComponent<NavMeshAgent>();
        //회전처리를 제한함
        agent.updateRotation = false;

        StartCoroutine(MonsterAction());
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            agent.SetDestination(targetTr.position);
            yield return ws;
        }
    }

    void Update()
    {
        // 몬스터가 추적중인 경우
        if (agent.desiredVelocity.sqrMagnitude >= 0.2f * 0.2f)
        {
            //이동방향
            Vector3 direction = agent.desiredVelocity;
            //회전각도 산출
            Quaternion rot = Quaternion.LookRotation(direction);
            //구면선형보간(Spherical Liner Interpolation)
            /*
                Vector3.Lerp = 선형 보간(Linear Interpolation)

                Quaternion.Slerp = 구면선형보간
            */
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 8.0f);
        }
    }


}
