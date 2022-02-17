using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_field_logic : MonoBehaviour
{
    private Rigidbody creature;
    private Animator animator;
    public float m_Thrust = 1f;
    private Vector3 changebig = new Vector3(0.05f, 0.05f, 0.05f);
    private Vector3 changesmall = new Vector3(0.005f, 0.005f, 0.005f);
    private Vector3 change = new Vector3(0f, 0f, 0f);
    private float sleep_time = 0f;
    private bool exploded = false;
    private void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null) { 
            var creature_pos = other.GetComponent<Rigidbody>().position;
            var own_pos = GetComponent<Transform>().position;
            var distance = Mathf.Pow((creature_pos.x - own_pos.x), 2) + Mathf.Pow((creature_pos.y - own_pos.y), 2) + Mathf.Pow((creature_pos.z - own_pos.z), 2);
            creature = other.GetComponent<Rigidbody>();
            var force = (creature_pos - own_pos) * m_Thrust / Mathf.Pow(distance, 2);
            var actual_force = Vector3.ClampMagnitude(force, 100f);
            creature.AddForce(actual_force, ForceMode.Acceleration);
            //Debug.Log("distance: " + distance);
        }
    }
    private void Update()
    {
        if (sleep_time > 0f)
        {
            if(sleep_time < 1.5f)
            {
                animator.SetBool("about_to_explode", true);
            }
            sleep_time -= Time.deltaTime;
            return;
        }
        animator.SetBool("about_to_explode", false);
        if (transform.localScale.y <= 0.1f)
        {
            if(exploded)
            {
                exploded = false;
                sleep_time = Random.Range(1, 5);
            }
            change = changebig;
        }
        else if (transform.localScale.y > 2.9f)
        { 
            change = -changesmall;
            exploded = true;
        }
        transform.localScale += change;
    }

}
