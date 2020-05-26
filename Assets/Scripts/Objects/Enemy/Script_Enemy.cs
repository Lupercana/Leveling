using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_to_track = null;

    [SerializeField]
    private float initial_speed = 0;

    // Rbody is too slow
    //private Rigidbody2D self_rbody;

    private void Awake()
    {
        //self_rbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (ref_to_track == null)
        {
            ref_to_track = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        float step = initial_speed * Time.deltaTime;

        Vector2 move = Vector2.MoveTowards(this.transform.position, ref_to_track.transform.position, step);

        this.transform.position = new Vector3(move.x, move.y, 0);
        //self_rbody.MovePosition(move);
    }
}
