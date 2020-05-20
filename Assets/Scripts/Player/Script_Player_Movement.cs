using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    public Rigidbody2D ref_rbody;

    void Update()
    {
        float h_axis = Input.GetAxis("Horizontal");
        float v_axis = Input.GetAxis("Vertical");

        ref_rbody.AddForce(new Vector2(h_axis, v_axis));
    }
}
