using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidLogic : MonoBehaviour
{
    private Animator animator;
    public bool end = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("collected");
    }

    // Update is called once per frame
    void Update()
    {
        if (end) 
        {
            Destroy(gameObject);
        }
        transform.Rotate(new Vector3(0f, 300f, 0f) * Time.deltaTime, Space.World);
    }
}
