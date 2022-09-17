using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghost.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        GameObject ghost2 = Instantiate(ghost, Vector3.zero, Quaternion.identity);
        ghost2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        GameObject ghost3 = Instantiate(ghost, Vector3.up, Quaternion.identity);
        ghost3.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        GameObject ghost4 = Instantiate(ghost, Vector3.down, Quaternion.identity);
        ghost4.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
