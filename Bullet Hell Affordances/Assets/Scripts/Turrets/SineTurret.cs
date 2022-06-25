using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineTurret : MonoBehaviour
{

    public float interval = 3;
    public SineBullet bullet;
    private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            Object.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), new Quaternion(1, 0, 0, 0));
            waiting = true;
            StartCoroutine(waiter(interval));
        }
    }

    IEnumerator waiter(float inter)
    {
        yield return new WaitForSeconds(inter);
        waiting = false;
    }
}

