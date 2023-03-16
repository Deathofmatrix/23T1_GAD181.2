using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor

{
    public class SheepSpawn : MonoBehaviour
    {
        public GameObject Sheep;

        public void SheepStart()
        {
            Instantiate(Sheep);
            Sheep.transform.position = new Vector3(40, 0, 0);
        }
    }
}