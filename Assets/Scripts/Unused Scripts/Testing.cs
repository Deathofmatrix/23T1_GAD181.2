using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class Testing : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Grid grid = new Grid(5, 7, 5f);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
        }
    }
}

