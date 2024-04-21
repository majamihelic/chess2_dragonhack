using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteboom : MonoBehaviour
{
    public GameObject board;
    private int player;

    Vector2Int xy = new Vector2Int();
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
            transform.position = new Vector3(-12f, -0.5f, -2f);
        }
        pulse += 3.5f * Time.deltaTime;
        pulse %= 2 * (float)System.Math.PI;
        transform.localRotation = Quaternion.Euler(0f, 0f, (float)System.Math.Sin(pulse) * 5f);

    }

    public void qte(int turn, Vector2Int loc)
    {
        xy = loc;
        player = turn;
        if (player == 0)
        {
            transform.position = new Vector3(-9f, -3.5f, -2f);
        }
        else
        {
            transform.position = new Vector3(9f, 3.5f, -2f);
        }

        timer = 1f;

    }

    void OnMouseDown()
    {
        player = -1;
        Dictionary<Vector2Int, GameObject> dict = board.GetComponent<init>().dict;
        if (xy.x > 0)
        {
            if (xy.y > 0)
            {
                if (dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y - 1))
                 && dict[new Vector2Int(xy.x - 1, xy.y - 1)].GetComponent<positioner>().tip != 5)
                {
                    if (dict[new Vector2Int(xy.x - 1, xy.y - 1)].GetComponent<positioner>().player == 1)
                    {
                        board.GetComponent<init>().count1--;
                    }
                    else board.GetComponent<init>().count2--;
                    dict[new Vector2Int(xy.x - 1, xy.y - 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x - 1, xy.y - 1));

                }
            }
            if (xy.y < 7)
            {
                if (dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y + 1)) && dict[new Vector2Int(xy.x - 1, xy.y + 1)].GetComponent<positioner>().tip != 5)
                {
                    if (dict[new Vector2Int(xy.x - 1, xy.y + 1)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                    else board.GetComponent<init>().count2--;
                    dict[new Vector2Int(xy.x - 1, xy.y + 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x - 1, xy.y + 1));
                }
            }

            if (dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y)) && dict[new Vector2Int(xy.x - 1, xy.y)].GetComponent<positioner>().tip != 5)
            {
                if (dict[new Vector2Int(xy.x - 1, xy.y)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                else board.GetComponent<init>().count2--;
                dict[new Vector2Int(xy.x - 1, xy.y)].SetActive(false); dict.Remove(new Vector2Int(xy.x - 1, xy.y));
            }
        }

        if (xy.x < 7)
        {
            if (xy.y > 0)
            {
                if (dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y - 1)) && dict[new Vector2Int(xy.x + 1, xy.y - 1)].GetComponent<positioner>().tip != 5)
                {
                    if (dict[new Vector2Int(xy.x + 1, xy.y - 1)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                    else board.GetComponent<init>().count2--;
                    dict[new Vector2Int(xy.x + 1, xy.y - 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x + 1, xy.y - 1));
                }
            }
        }
        if (xy.y < 7)
        {
            if (dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y + 1)) && dict[new Vector2Int(xy.x + 1, xy.y + 1)].GetComponent<positioner>().tip != 5)
            {
                if (dict[new Vector2Int(xy.x + 1, xy.y + 1)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                else board.GetComponent<init>().count2--;
                dict[new Vector2Int(xy.x + 1, xy.y + 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x + 1, xy.y + 1));
            }
        }

        if (dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y)) && dict[new Vector2Int(xy.x + 1, xy.y)].GetComponent<positioner>().tip != 5)
        {
            if (dict[new Vector2Int(xy.x + 1, xy.y)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
            else board.GetComponent<init>().count2--;
            dict[new Vector2Int(xy.x + 1, xy.y)].SetActive(false); dict.Remove(new Vector2Int(xy.x + 1, xy.y));
        }

        if (xy.y > 0)
        {
            if (dict.ContainsKey(new Vector2Int(xy.x, xy.y - 1)) && dict[new Vector2Int(xy.x, xy.y - 1)].GetComponent<positioner>().tip != 5)
            {
                if (dict[new Vector2Int(xy.x, xy.y - 1)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                else board.GetComponent<init>().count2--;
                dict[new Vector2Int(xy.x, xy.y - 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x, xy.y - 1));
            }
        }
        if (xy.y < 7)
        {
            if (dict.ContainsKey(new Vector2Int(xy.x, xy.y + 1)) && dict[new Vector2Int(xy.x, xy.y + 1)].GetComponent<positioner>().tip != 5)
            {
                if (dict[new Vector2Int(xy.x, xy.y + 1)].GetComponent<positioner>().player == 1) board.GetComponent<init>().count1--;
                else board.GetComponent<init>().count2--;
                dict[new Vector2Int(xy.x, xy.y + 1)].SetActive(false); dict.Remove(new Vector2Int(xy.x, xy.y + 1));
            }
        }

        if (dict[xy].GetComponent<positioner>().tip != 5)
        {
            if (player == 1) board.GetComponent<init>().count1--;
            else board.GetComponent<init>().count2--;

            dict[xy].SetActive(false); dict.Remove(xy);
        }
        transform.position = new Vector3(-12f, -0.5f, -2f);
    }
}
