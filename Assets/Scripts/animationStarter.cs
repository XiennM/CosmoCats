using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStarter : MonoBehaviour
{
    Animator animator;

    const string AnimStarter = "ButtonClick";
    const string AnimStoper = "ToGallery";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        animator.SetTrigger(AnimStarter);
    }
}
