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
    private void FixedUpdate()
    {
        CalculateMovement();
        RotatePlayer();
        MovePlayer();
    }
    private void CalculateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_newX = main_camera.transform.forward;
        m_newX.y = 0;
        m_newX.Normalize();
        m_newY = main_camera.transform.right;
        m_newY.y = 0;
        m_newY.Normalize();

        m_Movement = m_newY * horizontal + m_newX * vertical;
        m_Movement.Normalize();

    }
    private void RotatePlayer()
    {
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    private void MovePlayer()
    {
        if (!m_Movement.Equals(Vector3.zero))
        {
            m_Animator.SetInteger("animation", 18);
        }
        else
        {
            m_Animator.SetInteger("animation", 1);
        }
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * speed);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
