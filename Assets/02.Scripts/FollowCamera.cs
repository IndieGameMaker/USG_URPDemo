using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 추적 대상
    public Transform target;
    // 떨어져있는 거리
    [Range(0.0f, 10.0f)]
    public float distance = 3.0f;
    // 높이
    [Range(0.0f, 10.0f)]
    public float height = 3.0f;

    // 이동 Damping
    public float moveDamping = 2.0f;
    // 높이 Damping
    public float heightDamping = 2.0f;

    void LateUpdate()
    {
        Vector3 movePos = target.position - (Vector3.forward * distance) + (Vector3.up * height);
        // Smooth Move
        transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * moveDamping);

        // LookAt
        transform.LookAt(target.position);
    }
}
