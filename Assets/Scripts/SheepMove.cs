using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{

    [SerializeField] private GameObject barn;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        gameObject.tag = "Sheep";
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, barn.transform.position, moveSpeed * Time.deltaTime);
    }

}
