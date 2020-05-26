using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_bullet = null;

    [SerializeField]
    private float movement_speed = 0;

    [SerializeField]
    private float shot_speed = 0;

    private Rigidbody2D ref_rbody = null;

    private void Awake()
    {
        ref_rbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = movement_speed * Time.deltaTime;

        // Movement
        float h_axis = Input.GetAxis("Horizontal");
        float v_axis = Input.GetAxis("Vertical");

        ref_rbody.AddForce(new Vector2(h_axis, v_axis) * step);

        // Shooting
        bool shooting = Input.GetMouseButton(0);
        if (shooting)
        {
            Vector2 shot_dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            shot_dir.Normalize();

            GameObject inst = Instantiate(ref_bullet, this.transform.position, Quaternion.identity);
            inst.GetComponent<Rigidbody2D>().velocity = shot_dir * shot_speed;
        }
    }
}
