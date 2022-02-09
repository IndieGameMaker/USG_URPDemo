using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private new Transform transform;
    private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
