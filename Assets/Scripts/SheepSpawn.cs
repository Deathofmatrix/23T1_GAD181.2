using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawn : MonoBehaviour
{
    public GameObject Sheep;

    public void SheepStart()
    {
        Instantiate(Sheep);
        Sheep.transform.position = new Vector3(20, 1, 17);
    }
}
