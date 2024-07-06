using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseIP : MonoBehaviour
{
    public float sensitivityX = 0.5f; // ������
    public float sensitivityY = 0.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private Vector3 lastMousePosition;
    private bool isLocked = true;

    // �������������������ʼ�� targetPosition �� smoothSpeed

    public Transform targetToFollow; // Ŀ�����壬����ƽ������
    public float smoothSpeed = 0.125f; // ƽ�������ٶ�

    private Vector3 targetPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ��ʼ�� targetPosition ΪĿ�������λ��
        targetPosition = targetToFollow.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyUp(KeyCode.LeftAlt)|| Input.GetKeyUp(KeyCode.RightAlt))
        {
            isLocked = !isLocked;
            Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isLocked;
        }

        // ����걻����ʱ�������������
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

            // �������������ת�Ƕ�
            rotationX += mouseX;
            rotationY -= mouseY;

            // Ӧ����ת�����ִ�ֱ�Ƕ��ں���Χ��
            rotationX = Mathf.Repeat(rotationX, 360);
            rotationY = Mathf.Clamp(rotationY, -20f, 20f);

            // ������ת��Ԫ��
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0f);

            // ����תӦ�õ������
            transform.rotation = rotation;

            // ����������������
            transform.position= targetPosition;
        }
    }

    void LateUpdate()
    {
        // ��������ǰ���Ƿ�����ײ
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f)) // �ɵ����ľ���
        {
            // �������ײ���������λ�õ������Ӵ���
            transform.position = hit.point;
        }

        // ƽ������Ŀ������
        targetPosition = targetToFollow.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
