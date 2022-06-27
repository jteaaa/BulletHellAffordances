using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.localScale = new Vector3 (0.65f, 0.65f, 0.65f);
            Destroy(this.gameObject);
        }
    }
}
