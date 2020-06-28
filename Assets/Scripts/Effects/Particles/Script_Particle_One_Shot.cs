using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Particle_One_Shot : MonoBehaviour
{
    private ParticleSystem pe = null;

    public void SetColor(Color color)
    {
        ParticleSystem.MainModule main = pe.main;
        main.startColor = color;
    }

    public void SetScale(float scale_x, float scale_y)
    {
        ParticleSystem.CollisionModule colli = pe.collision;
        colli.radiusScale = Mathf.Max(scale_x, scale_y);
        this.transform.localScale = new Vector2(scale_x, scale_y);
    }

    public void Play()
    {
        pe.Play();
    }

    private void Awake()
    {
        pe = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!pe.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
