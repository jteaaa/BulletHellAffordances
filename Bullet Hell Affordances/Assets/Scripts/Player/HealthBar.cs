using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Transform bar;
    

    // Start is called before the first frame update
    private void Start()
    {
        //bar.localScale = new Vector3(1f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);

    }
}
