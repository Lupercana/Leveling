using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Behavior : MonoBehaviour
{
    [SerializeField]
    private GameObject ref_bullet = null;
    [SerializeField]
    private string tag_enemy = "";
    [SerializeField]
    private float movement_speed = 0;
    [SerializeField]
    private int max_health = 0;
    [SerializeField]
    private int enemy_damage = 0;
    [SerializeField]
    private float shot_speed = 0;
    [SerializeField]
    private float shot_cd_seconds = 0;
    [SerializeField]
    private float hit_cd_seconds = 0;

    private Rigidbody2D ref_rbody = null;
    private int current_health = 0;
    private float last_shot_time = 0;
    private float last_hit_time = 0;

    private void Awake()
    {
        ref_rbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        current_health = max_health;
    }

    void Update()
    {
        // Visuals update
        float c = current_health / (float) max_health;
        this.GetComponent<SpriteRenderer>().material.color = new Color(c, c, c);
        
        // Movement
        float step = movement_speed * Time.deltaTime;
        
        float h_axis = Input.GetAxis("Horizontal");
        float v_axis = Input.GetAxis("Vertical");

        ref_rbody.AddForce(new Vector2(h_axis, v_axis) * step);

        // Shooting
        bool shooting = Input.GetMouseButton(0);
        float elapsed_time = Time.time - last_shot_time;
        if (shooting && elapsed_time > (shot_cd_seconds))
        {
            Vector2 shot_dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            shot_dir.Normalize();

            GameObject inst = Instantiate(ref_bullet, this.transform.position, Quaternion.identity);
            inst.GetComponent<Rigidbody2D>().velocity = shot_dir * shot_speed;
            last_shot_time = Time.time;
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == tag_enemy)
        {
            if (current_health > 0)
            {
                float elapsed_time = Time.time - last_hit_time;

                if (elapsed_time > hit_cd_seconds)
                {
                    current_health -= enemy_damage;
                    this.GetComponent<Script_Effect_Resize>().TriggerResize();
                    if (current_health < 0)
                    {
                        current_health = 0;
                    }
                    last_hit_time = Time.time;
                }
            }
        }
    }
}
