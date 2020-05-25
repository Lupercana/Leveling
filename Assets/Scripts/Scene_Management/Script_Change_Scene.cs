using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Change_Scene : MonoBehaviour
{
    [SerializeField]
    private Object ref_next_scene = null;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(ref_next_scene.name);
    }
}
