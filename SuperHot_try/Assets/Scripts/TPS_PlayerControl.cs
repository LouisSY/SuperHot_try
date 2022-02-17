using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_PlayerControl : MonoBehaviour
{

    private TPS_CharacterMovement _tps_characterMovment;
    
    [SerializeField]        //私有的同时还能从外面获得赋值
    private TPS_CameraController _tps_cameraController;

    [SerializeField]
    private Transform _followingTarget;

    private bool end = false;
    public GameObject robot;
    private void Awake()
    {
        _tps_characterMovment = GetComponent<TPS_CharacterMovement>();
        _tps_cameraController.InitCamera(_followingTarget);
    }


    void Update()
    {
        rotateWithCamera();
        if (!end) { 
            end = GetComponentInChildren<RobotFreeAnim>().end;
            if (!end) {
                return;
            }     
        }
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Quaternion rotation = Quaternion.Euler(0, _tps_cameraController.rotate_along_y, 0);      //沿y轴旋转的方向为正方向
        Vector3 forward_movement = rotation * Vector3.forward * Input.GetAxis("Vertical");       //正方向移动距离
        Vector3 right_movement = rotation * Vector3.right * Input.GetAxis("Horizontal");         //侧方向移动距离
        _tps_characterMovment.setInput(forward_movement + right_movement);
    }

    private void rotateWithCamera()
    {
         Quaternion rotation = Quaternion.Euler(0, _tps_cameraController.rotate_along_y, 0);      //沿y轴旋转的方向为正方向
         robot.transform.rotation = rotation;
    }
}
