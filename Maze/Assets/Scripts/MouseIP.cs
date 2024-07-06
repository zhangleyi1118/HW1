using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseIP : MonoBehaviour
{
    public float sensitivityX = 0.5f; // 灵敏度
    public float sensitivityY = 0.5f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private Vector3 lastMousePosition;
    private bool isLocked = true;

    // 添加以下行以声明并初始化 targetPosition 和 smoothSpeed

    public Transform targetToFollow; // 目标物体，用于平滑跟随
    public float smoothSpeed = 0.125f; // 平滑跟随速度

    private Vector3 targetPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 初始化 targetPosition 为目标物体的位置
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

        // 当鼠标被锁定时，处理鼠标输入
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

            // 更新摄像机的旋转角度
            rotationX += mouseX;
            rotationY -= mouseY;

            // 应用旋转，保持垂直角度在合理范围内
            rotationX = Mathf.Repeat(rotationX, 360);
            rotationY = Mathf.Clamp(rotationY, -20f, 20f);

            // 构建旋转四元数
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0f);

            // 将旋转应用到摄像机
            transform.rotation = rotation;

            // 保持摄像机面向玩家
            transform.position= targetPosition;
        }
    }

    void LateUpdate()
    {
        // 检测摄像机前方是否有碰撞
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f)) // 可调整的距离
        {
            // 如果有碰撞，将摄像机位置调整到接触点
            transform.position = hit.point;
        }

        // 平滑跟随目标物体
        targetPosition = targetToFollow.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
