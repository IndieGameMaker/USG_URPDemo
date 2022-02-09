using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 추적 대상
    public Transform target;
    // 떨어져있는 거리
    [Range(-10.0f, 0.0f)]
    public float distance = -3.0f;
    // 높이
    [Range(0.0f, 10.0f)]
    public float height = 3.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
