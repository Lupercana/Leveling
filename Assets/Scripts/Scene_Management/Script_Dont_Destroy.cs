using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Dont_Destroy : MonoBehaviour
{
    [SerializeField]
    private string tag = null;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
