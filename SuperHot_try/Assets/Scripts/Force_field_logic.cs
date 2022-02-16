using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_field_logic : MonoBehaviour
{
    private Rigidbody creature;
    public float m_Thrust = 2f;

   
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null) { 
            var creature_pos = other.GetComponent<Rigidbody>().position;
            var own_pos = GetComponent<Transform>().position;
            var distance = Mathf.Pow((creature_pos.x - own_pos.x), 2) + Mathf.Pow((creature_pos.y - own_pos.y), 2) + Mathf.Pow((creature_pos.z - own_pos.z), 2);
            creature = other.GetComponent<Rigidbody>();
            creature.AddForce((creature_pos - own_pos) * m_Thrust/ Mathf.Pow(distance, 5), ForceMode.VelocityChange);
            Debug.Log("distance: " + distance);
        }
    }

}
