using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 180;

    [Range(1, 3)]
    public float Sensitivity = 1;
    public Transform playerBody_trans;
    public Transform playerCamera_trans;
    private float x_offset_rotate;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RotateControl();
    }

    private void RotateControl()
    {
        if(playerBody_trans == null || playerCamera_trans == null) return; //防止屏幕疯狂闪烁

        // 虚拟轴
        float x_offset = Input.GetAxis("Mouse X"); // 左右移动
        float y_offset = Input.GetAxis("Mouse Y"); // 上下移动

        var constant = rotateSpeed * Sensitivity * Time.fixedDeltaTime;

        // 左右偏移量
        playerBody_trans.Rotate(Vector3.up * x_offset * constant);

        // 上下偏移量
        x_offset_rotate -= y_offset * constant;                                  // vec3.x 
        float y_offset_rotate = playerCamera_trans.localEulerAngles.y;           // vec3.y
        float z_offset_rotate = playerCamera_trans.localEulerAngles.z;           // vec3.z
        Vector3 offset_rotate = new Vector3(x_offset_rotate, y_offset_rotate, z_offset_rotate);
        Quaternion currentQuaternion_local = Quaternion.Euler(offset_rotate);
        playerCamera_trans.localRotation = currentQuaternion_local;

    }
}
