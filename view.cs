using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{
    public int pogoj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float pulse = 0;
    void Update()
    {
        pulse += 1.5f * Time.deltaTime;
        pulse %= 2 * (float)System.Math.PI;
        transform.localScale = new Vector3(1.8f, 1.8f, 0f) + new Vector3((float)System.Math.Sin(pulse) * 0.2f, (float)System.Math.Sin(pulse) * 0.2f, 0);
    }
}
