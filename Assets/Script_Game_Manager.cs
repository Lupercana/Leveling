using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Game_Manager : MonoBehaviour
{
    [SerializeField]
    private uint starting_level = 0;

    private uint level = 0;

    public uint GetLevel()
    {
        return level;
    }

    void Start()
    {
        level = starting_level;
    }

    void Update()
    {
        
    }
}
