using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speed = 0.02f;
    public Camera main_camera;

    Animator m_Animator;
    Rigidbody m_Rigidbody;

    Vector3 m_Movement;
    Vector3 m_newX;
    Vector3 m_newY;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_newX = main_camera.transform.forward;
        m_newX.y = 0;
        m_newX.Normalize();
        m_newY = main_camera.transform.right;
        m_newY.y = 0;
        m_newY.Normalize();

        m_Movement = m_newY* horizontal + m_newX * vertical;
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("If_Walking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement*speed);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
