using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private new Transform transform;
    private new Camera camera;

    // 가상의 Plane
    private Plane plane;
    private Ray ray;
    private RaycastHit hit;

    // 키보드 입력값
    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        camera = Camera.main;

        plane = new Plane(transform.up, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

    }
}
