using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_spawn_type = null;

    [SerializeField]
    private int max_spawns_on_screen = 0;

    private float side_up;
    private float side_down;
    private float side_left;
    private float side_right;

    private float spawn_extent_x;
    private float spawn_extent_y;

    void Start()
    {
        Vector2 pos = this.transform.position;
        Vector2 size = this.transform.localScale;
        side_up = pos.y - size.y / 2.0f;
        side_down = pos.y + size.y / 2.0f;
        side_left = pos.x - size.x / 2.0f;
        side_right = pos.x + size.x / 2.0f;

        Collider2D ref_collider = ref_spawn_type.GetComponent<Collider2D>();
        spawn_extent_x = ref_collider.bounds.extents.x;
        spawn_extent_y = ref_collider.bounds.extents.y;
    }

    void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length < max_spawns_on_screen)
        {
            float spawn_x = Random.Range(side_left + spawn_extent_x, side_right - spawn_extent_x);
            float spawn_y = Random.Range(side_up + spawn_extent_y, side_down - spawn_extent_y);

            Instantiate(ref_spawn_type, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
        }
    }
}
