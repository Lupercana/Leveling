using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Dont_Destroy : MonoBehaviour
{
    [SerializeField]
    private string tag_to_find = "";

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag_to_find);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
