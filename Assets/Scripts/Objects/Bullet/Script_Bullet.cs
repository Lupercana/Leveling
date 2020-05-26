using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bullet : MonoBehaviour
{
    [SerializeField]
    private string tag_destroy = "";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == tag_destroy)
        {
            Destroy(this.gameObject);
        }
    }
}
