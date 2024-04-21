using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteswap : MonoBehaviour
{
    public GameObject board;
    private int player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float pulse = 0;
    float timer = 0;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            transform.position = new Vector3(-12f, -1.5f, -2f);
        }
        pulse += 3.5f * Time.deltaTime;
        pulse %= 2 * (float)System.Math.PI;
        transform.localRotation = Quaternion.Euler(0f, 0f, (float)System.Math.Sin(pulse) * 5f);

    }

    public void qte(int turn)
    {
        player = turn;
        if (player == 0)
        {
            transform.position = new Vector3(-9f, -3.5f, -2f);
        }
        else
        {
            transform.position = new Vector3(9f, 3.5f, -2f);
        }

        timer = 2f;

    }

    void OnMouseDown()
    {
        board.GetComponent<init>().turn = player;
        player = -1;
        board.GetComponent<init>().swappy = true;
        transform.position = new Vector3(-12f, -1.5f, -2f);
    }
}
