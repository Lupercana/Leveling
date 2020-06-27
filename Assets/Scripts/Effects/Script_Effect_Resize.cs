using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Effect_Resize : MonoBehaviour
{
    [SerializeField] private bool expand_x = true;
    [SerializeField] private bool expand_y = true;
    [SerializeField] private bool expand_z = true;
    [SerializeField] private float amount_multiply = 1.5f;
    [SerializeField] private float duration_seconds = 0.1f;

    private Vector3 original_scale;
    private float last_time;

    public void TriggerResize()
    {
        Vector3 new_size = original_scale;
        if (expand_x)
        {
            new_size.x *= amount_multiply;
        }
        if (expand_y)
        {
            new_size.y *= amount_multiply;
        }
        if (expand_z)
        {
            new_size.z *= amount_multiply;
        }
        transform.localScale = new_size;

        last_time = Time.time;
    }

    private void Start()
    {
        original_scale = this.transform.localScale;
        last_time = Time.time;
    }

    private void Update()
    {
        if ((Time.time - last_time) > duration_seconds)
        {
            transform.localScale = original_scale;
        }
    }
}
