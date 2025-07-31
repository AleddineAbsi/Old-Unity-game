using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    public float max_x;
    public float min_x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < max_x)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0 , 0);
        }
        if (transform.position.x >= max_x)
        {
            transform.position = new Vector3(min_x, y, 0);
        }
    }
}
