using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red;   
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(new Vector3(-0.01f, 0)); ??? ????? ??? ???
        GetComponent<Transform>().Translate(new Vector3(-0.01f, 0));
    }
}
