using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimations : MonoBehaviour
{
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    public GameObject ghost4;

    // Start is called before the first frame update
    void Start()
    {
        ghost1.GetComponent<SpriteRenderer>().color = Color.yellow;
        ghost2.GetComponent<SpriteRenderer>().color = Color.red;
        ghost3.GetComponent<SpriteRenderer>().color = Color.magenta;
        ghost4.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
