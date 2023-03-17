using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class Sheep : MonoBehaviour
    {

        [SerializeField] private GameObject barn;
        [SerializeField] private float moveSpeed;

        private void Start()
        {
            gameObject.tag = "Sheep";
        }

        private void Update()
        {
            SheepMove();
        }
        
        private void SheepMove()
        {
            transform.position = Vector3.MoveTowards(transform.position, barn.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}