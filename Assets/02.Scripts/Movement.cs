using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private new Transform transform;
    private new Camera camera;

    // 가상의 Plane
    private Plane plane;
    private Ray ray;
    private Vector3 hitPoint;

    // 키보드 입력값
    float h;// => Input.GetAxis("Horizontal");
    float v;// => Input.GetAxis("Vertical");

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
        Turn();
    }

    void Move()
    {
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;

        cameraForward.y = cameraRight.y = 0.0f;

        Vector3 moveDir = (cameraForward * v) + (cameraRight * h);
        moveDir.Set(moveDir.x, 0.0f, moveDir.z);

        controller.SimpleMove(moveDir.normalized * 10.0f);

        //주인공 캐릭터의 애니메이션
        float forward = Vector3.Dot(moveDir, transform.forward);
        float strafe = Vector3.Dot(moveDir, transform.right);

        anim.SetFloat("Forward", forward);
        anim.SetFloat("Strafe", strafe);
    }

    void Turn()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        plane.Raycast(ray, out enter);

        hitPoint = ray.GetPoint(enter);

        Vector3 lookDir = hitPoint - transform.position;
        lookDir.y = 0.0f;

        transform.localRotation = Quaternion.LookRotation(lookDir);
    }

    //void OnMove(InputValue value) // SendMessage 방식
    void OnMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();

        Debug.Log($"Move = ({dir.x} , {dir.y} )");
        v = dir.y;
        h = dir.x;
    }

    void OnFire(InputAction.CallbackContext ctx)
    {
        Debug.Log("ctx.phase = " + ctx.phase);
        if (ctx.performed)
        {
            Debug.Log("Fire !!!");
        }
    }
}
