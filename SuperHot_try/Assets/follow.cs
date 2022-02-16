using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject focuspoint = null;
    // Update is called once per frame
    private void Start()
    {
        transform.LookAt(focuspoint.GetComponent<Transform>());
    }
    void Update()
    {
        if (focuspoint == null) { return; }
        GetComponent<Transform>().position = focuspoint.GetComponent<Transform>().position + new Vector3(0,2,-1);
    }
}
