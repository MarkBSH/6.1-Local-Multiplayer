using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineAnimationSpeed : MonoBehaviour
{
    Animator animator;
    [SerializeField] float animSpeedControl = 1f;
    void Start()
    {
        animSpeedControl = Random.Range(0.8f, 1.3f);
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("Float", animSpeedControl);
    }

}
