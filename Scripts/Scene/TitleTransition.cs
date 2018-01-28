using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTransition : MonoBehaviour
{
    [SerializeField] FadeScreen screen;
    JumpToScene jumpToScene;

    private void Start()
    {
        jumpToScene = GetComponent<JumpToScene>();
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("transition");
            jumpToScene.Exicute();
        }
	}
}
