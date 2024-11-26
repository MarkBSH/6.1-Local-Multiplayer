using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMouse : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPro;
    private float distance; 
    [SerializeField] private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, startPosition);
        distance = distance / 3;
        TMPro.text = "m " + distance.ToString("F2") ;
    }
}
