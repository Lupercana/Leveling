using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    [SerializeField]
    private int speed = 0;

    private Rigidbody2D ref_rbody = null;

    private void Awake()
    {
        ref_rbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        float h_axis = Input.GetAxis("Horizontal");
        float v_axis = Input.GetAxis("Vertical");

        ref_rbody.AddForce(new Vector2(h_axis, v_axis) * step);
    }
}
