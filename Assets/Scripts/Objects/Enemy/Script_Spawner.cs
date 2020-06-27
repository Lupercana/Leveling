using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_GM = null;
    [SerializeField]
    private GameObject ref_spawn_type = null;
    [SerializeField]
    private int spawn_limit = 0; // Absolute limit on screen spawns, this is a global limit, not per spawner

    private int difficulty_max_spawns = 0;
    private float difficulty_spawn_speed_max_cd = 0;
    private float spawn_cd = 0;
    private float last_spawn_time = 0;
    private float side_up = 0;
    private float side_down = 0;
    private float side_left = 0;
    private float side_right = 0;
    private float spawn_extent_x = 0;
    private float spawn_extent_y = 0;

    void Start()
    {
        // Determine spawn difficulty based on current level
        uint level = ref_GM.GetComponent<Script_Game_Manager>().GetLevel();

        difficulty_max_spawns = (int) (10f * Mathf.Exp(0.0032f * level));
        difficulty_spawn_speed_max_cd = 5f - 0.005f * level;
        spawn_cd = Random.value * difficulty_spawn_speed_max_cd;

        // Prevents game from being too CPU intensive
        if (difficulty_max_spawns > spawn_limit)
        {
            difficulty_max_spawns = spawn_limit;
        }
        if (difficulty_spawn_speed_max_cd < 0)
        {
            difficulty_spawn_speed_max_cd = 0;
        }

        // Calculate spawn bounds
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
        float elapsed_time = Time.time - last_spawn_time;
        if (elapsed_time > spawn_cd)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            if (gos.Length < difficulty_max_spawns)
            {
                float spawn_x = Random.Range(side_left + spawn_extent_x, side_right - spawn_extent_x);
                float spawn_y = Random.Range(side_up + spawn_extent_y, side_down - spawn_extent_y);

                Instantiate(ref_spawn_type, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);

                last_spawn_time = Time.time;
                spawn_cd = Random.value * difficulty_spawn_speed_max_cd;
            }
        }
    }
}
