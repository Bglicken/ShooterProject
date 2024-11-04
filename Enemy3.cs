using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime * 6f);

        if (transform.position.y < -8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
