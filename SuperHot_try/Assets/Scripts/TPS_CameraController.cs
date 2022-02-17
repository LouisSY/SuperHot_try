using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_CameraController : MonoBehaviour
{
    public float rotate_along_x   { get; private set; }  //Pitch
    public float rotate_along_y   { get; private set; }  //Yaw
 
    [Range(0, 5)]
    [Tooltip("Change the sensitivity of mouse")]
    public float mouseSensitivity = 5;

    [Range(0, 5)]
    public float speed_Y = 5;
    private Transform _target;       // The ohject that the camera is following
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationControll();
        positionControl();
    }

    private void rotationControll()
    {
        rotate_along_y += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotate_along_x -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotate_along_x = Mathf.Clamp(rotate_along_x, -60, 60);

        transform.rotation = Quaternion.Euler(rotate_along_x, rotate_along_y, 0);
    }

    public void InitCamera(Transform target)
    {
        _target = target;
        transform.position = target.position;
    }

    private void positionControl()
    {
        //水平方向跟随 竖直方向有差值
        float pos_y = Mathf.Lerp(transform.position.y, _target.position.y, Time.deltaTime * speed_Y);
        float pos_x = _target.position.x;
        float pos_z = _target.position.z;

        Vector3 newPos = new Vector3(pos_x, pos_y, pos_z);

        transform.position = newPos;
        // transform.position = _target.position;
    }
}
