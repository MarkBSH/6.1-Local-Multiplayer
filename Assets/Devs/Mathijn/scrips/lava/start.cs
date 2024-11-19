using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator.Play("lavawave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
