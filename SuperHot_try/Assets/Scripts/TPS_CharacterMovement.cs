using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TPS_CharacterMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector3 currInput { get; private set; }
    [Range(0, 50)]
    public float moveSpeed = 5;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + currInput * moveSpeed * Time.fixedDeltaTime);
    }

    public void setInput(Vector3 input)
    {
        currInput = Vector3.ClampMagnitude(input, 1);
    }

}
