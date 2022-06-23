using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float duration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter(duration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Destroy(this.gameObject);
    }
}
