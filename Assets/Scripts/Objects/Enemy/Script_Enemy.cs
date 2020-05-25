using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_to_track;

    [SerializeField]
    private float speed;

    private Rigidbody2D self_rbody;

    private void Awake()
    {
        self_rbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        Vector2 move = Vector2.MoveTowards(self_rbody.transform.position, ref_to_track.transform.position, step);

        self_rbody.MovePosition(move);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
