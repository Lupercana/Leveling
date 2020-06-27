using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_to_track = null;

    [SerializeField]
    private string tag_destroy = "";

    [SerializeField]
    private float initial_speed = 0;

    private Rigidbody2D self_rbody;

    private void Awake()
    {
        self_rbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (ref_to_track == null)
        {
            ref_to_track = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        float step = initial_speed * Time.fixedDeltaTime;

        Vector3 move = Vector3.MoveTowards(this.transform.position, ref_to_track.transform.position, step);

        self_rbody.MovePosition(move);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == tag_destroy)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
