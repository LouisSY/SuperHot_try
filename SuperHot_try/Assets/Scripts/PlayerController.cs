using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 180;
    [Range(0.5F, 5)]
    public float moveSpeed = 1;

    [Range(1, 3)]
    public float Sensitivity = 1;
    public Transform playerCamera_trans;
    private float x_rotation;

    public CharacterController _player_moveControl;

    void Start()
    {
        // playerCamera_trans.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        
    }

    void Update()
    {
        moveControll();
        RotateControl();
    }

    private void moveControll()
    {
        if(_player_moveControl == null) return;

        float move_left_right = Input.GetAxis("Horizontal");
        float move_ahead_back = Input.GetAxis("Vertical");

        Vector3 moveInfo = Vector3.zero;
        float coeff = moveSpeed * Time.deltaTime;
        moveInfo = (this.transform.forward * move_ahead_back + this.transform.right * move_left_right) * coeff;
        _player_moveControl.Move(moveInfo);
    }

    private void RotateControl()
    {
        if(playerCamera_trans == null) return; //防止屏幕疯狂闪烁


        // 虚拟轴
        float x_offset = Input.GetAxis("Mouse X"); // 左右移动
        float y_offset = Input.GetAxis("Mouse Y"); // 上下移动

        var coeff = rotateSpeed * Sensitivity * Time.deltaTime;

        // 左右偏移量
        this.gameObject.transform.Rotate(Vector3.up * x_offset * coeff);

        // 上下偏移量
        x_rotation -= y_offset * coeff;                                     // vec3.x 
        x_rotation = Mathf.Clamp(x_rotation, -35, 75);                 // limit x
        Vector3 offset_rotate = new Vector3(x_rotation, 0, 0);
        Quaternion q = Quaternion.Euler(offset_rotate);
        playerCamera_trans.localRotation = q;

    }


}
