using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class positioner : MonoBehaviour
{
    public GameObject board;
    public Vector2Int xy;
    public int player;
    public int tip;
    Collision2D collision;
    private bool tileselect = false;
    public GameObject qtex2;
    public GameObject qteswap;
    private bool swapselect = false;

    public GameObject qteboom;



    // Start is called before the first frame update

    string lts(List<Vector2Int> list)
    {
        string strig = "";
        for (int i = 0; i < list.Count; i++)
        {
            strig += list[i] + " ";
        }
        return strig;
    }
    void Start()
    {

    }

    List<Vector2Int> eval()
    {
        Dictionary<Vector2Int, GameObject> dict = board.GetComponent<init>().dict;

        List<Vector2Int> list = new List<Vector2Int>();
        switch (tip)
        {
            case 5: //kralj
                {
                    if (xy.x > 0)
                    {
                        if (xy.y > 0)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y - 1)) || dict[new Vector2Int(xy.x - 1, xy.y - 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 1, xy.y - 1));
                        }
                        if (xy.y < 7)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y + 1)) || dict[new Vector2Int(xy.x - 1, xy.y + 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 1, xy.y + 1));
                        }
                        if (!dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y)) || dict[new Vector2Int(xy.x - 1, xy.y)].GetComponent<positioner>().player != player)
                            list.Add(new Vector2Int(xy.x - 1, xy.y));
                    }
                    if (xy.x < 7)
                    {
                        if (xy.y > 0)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y - 1)) || dict[new Vector2Int(xy.x + 1, xy.y - 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 1, xy.y - 1));
                        }
                        if (xy.y < 7)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y + 1)) || dict[new Vector2Int(xy.x + 1, xy.y + 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 1, xy.y + 1));
                        }
                        if (!dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y)) || dict[new Vector2Int(xy.x + 1, xy.y)].GetComponent<positioner>().player != player)
                            list.Add(new Vector2Int(xy.x + 1, xy.y));
                    }
                    if (xy.y > 0)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, xy.y - 1)) || dict[new Vector2Int(xy.x, xy.y - 1)].GetComponent<positioner>().player != player)
                            list.Add(new Vector2Int(xy.x, xy.y - 1));
                    }
                    if (xy.y < 7)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, xy.y + 1)) || dict[new Vector2Int(xy.x, xy.y + 1)].GetComponent<positioner>().player != player)
                            list.Add(new Vector2Int(xy.x, xy.y + 1));
                    }
                    break;
                }
            case 4: //kraljica
                {
                    //desno
                    for (int i = xy.x + 1; i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(i, xy.y)))
                            list.Add(new Vector2Int(i, xy.y));
                        else
                        {
                            if (dict[new Vector2Int(i, xy.y)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(i, xy.y));
                            break;
                        }
                    }
                    //gor
                    for (int i = xy.y + 1; i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, i)))
                            list.Add(new Vector2Int(xy.x, i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x, i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x, i));
                            break;

                        }
                    }
                    //levo
                    for (int i = xy.x - 1; i >= 0; i--)
                    {
                        if (!dict.ContainsKey(new Vector2Int(i, xy.y)))
                            list.Add(new Vector2Int(i, xy.y));
                        else
                        {
                            if (dict[new Vector2Int(i, xy.y)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(i, xy.y));
                            break;
                        }
                    }

                    //dol
                    for (int i = xy.y - 1; i >= 0; i--)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, i)))
                            list.Add(new Vector2Int(xy.x, i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x, i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x, i));
                            break;

                        }
                    }

                    //gor desno diagonala
                    for (int i = 1; xy.x + i < 8 && xy.y + i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x + i, xy.y + i)))
                            list.Add(new Vector2Int(xy.x + i, xy.y + i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x + i, xy.y + i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + i, xy.y + i));
                            break;

                        }
                    }

                    //gor levo diagonala       
                    for (int i = 1; xy.x - i >= 0 && xy.y + i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x - i, xy.y + i)))
                            list.Add(new Vector2Int(xy.x - i, xy.y + i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x - i, xy.y + i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - i, xy.y + i));
                            break;

                        }
                    }

                    //dol desno diagonala       
                    for (int i = 1; xy.x + i < 8 && xy.y - i >= 0; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x + i, xy.y - i)))
                            list.Add(new Vector2Int(xy.x + i, xy.y - i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x + i, xy.y - i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + i, xy.y - i));
                            break;

                        }
                    }

                    //dol levo diagonala       
                    for (int i = 1; xy.x - i >= 0 && xy.y - i >= 0; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x - i, xy.y - i)))
                            list.Add(new Vector2Int(xy.x - i, xy.y - i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x - i, xy.y - i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - i, xy.y - i));
                            break;

                        }
                    }

                    break;
                }
            case 3: //lovec (kot kraljica brez vodoravnih in navpičnih)
                {
                    //gor desno diagonala
                    for (int i = 1; xy.x + i < 8 && xy.y + i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x + i, xy.y + i)))
                            list.Add(new Vector2Int(xy.x + i, xy.y + i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x + i, xy.y + i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + i, xy.y + i));
                            break;

                        }
                    }

                    //gor levo diagonala       
                    for (int i = 1; xy.x - i >= 0 && xy.y + i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x - i, xy.y + i)))
                            list.Add(new Vector2Int(xy.x - i, xy.y + i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x - i, xy.y + i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - i, xy.y + i));
                            break;

                        }
                    }

                    //dol desno diagonala       
                    for (int i = 1; xy.x + i < 8 && xy.y - i >= 0; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x + i, xy.y - i)))
                            list.Add(new Vector2Int(xy.x + i, xy.y - i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x + i, xy.y - i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + i, xy.y - i));
                            break;

                        }
                    }
                    //dol levo
                    for (int i = 1; xy.x - i >= 0 && xy.y - i >= 0; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x - i, xy.y - i)))
                            list.Add(new Vector2Int(xy.x - i, xy.y - i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x - i, xy.y - i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - i, xy.y - i));
                            break;

                        }
                    }
                    break;
                }
            case 2: //zmaj (gleda max 8 polj in lahko preskakuje)
                {

                    //x+2, y+1; x+2, y-1
                    if (xy.x + 2 < 8)
                    {
                        if (xy.y + 1 < 8)
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 2, xy.y + 1)) || dict[new Vector2Int(xy.x + 2, xy.y + 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 2, xy.y + 1));
                        if (xy.y - 1 >= 0)
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 2, xy.y - 1)) || dict[new Vector2Int(xy.x + 2, xy.y - 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 2, xy.y - 1));
                    }

                    //x+1, y+2; x+1, y-2
                    if (xy.x + 1 < 8)
                    {
                        if (xy.y + 2 < 8)
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y + 2)) || dict[new Vector2Int(xy.x + 1, xy.y + 2)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 1, xy.y + 2));
                        if (xy.y - 2 >= 0)
                            if (!dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y - 2)) || dict[new Vector2Int(xy.x + 1, xy.y - 2)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x + 1, xy.y - 2));
                    }

                    //x-2, y+1; x-2, y-1
                    if (xy.x - 2 >= 0)
                    {
                        if (xy.y + 1 < 8)
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 2, xy.y + 1)) || dict[new Vector2Int(xy.x - 2, xy.y + 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 2, xy.y + 1));
                        if (xy.y - 1 >= 0)
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 2, xy.y - 1)) || dict[new Vector2Int(xy.x - 2, xy.y - 1)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 2, xy.y - 1));
                    }

                    //x-1, y+2; x-1, y-2
                    if (xy.x - 1 >= 0)
                    {
                        if (xy.y + 2 < 8)
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y + 2)) || dict[new Vector2Int(xy.x - 1, xy.y + 2)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 1, xy.y + 2));
                        if (xy.y - 2 >= 0)
                            if (!dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y - 2)) || dict[new Vector2Int(xy.x - 1, xy.y - 2)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x - 1, xy.y - 2));
                    }

                    break;
                }
            case 1: //trdnjava (kot kraljica brez diagonal)
                {
                    //desno
                    for (int i = xy.x + 1; i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(i, xy.y)))
                            list.Add(new Vector2Int(i, xy.y));
                        else
                        {
                            if (dict[new Vector2Int(i, xy.y)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(i, xy.y));
                            break;
                        }
                    }
                    //gor
                    for (int i = xy.y + 1; i < 8; i++)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, i)))
                            list.Add(new Vector2Int(xy.x, i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x, i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x, i));
                            break;

                        }
                    }
                    //levo
                    for (int i = xy.x - 1; i >= 0; i--)
                    {
                        if (!dict.ContainsKey(new Vector2Int(i, xy.y)))
                            list.Add(new Vector2Int(i, xy.y));
                        else
                        {
                            if (dict[new Vector2Int(i, xy.y)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(i, xy.y));
                            break;
                        }
                    }

                    //dol
                    for (int i = xy.y - 1; i >= 0; i--)
                    {
                        if (!dict.ContainsKey(new Vector2Int(xy.x, i)))
                            list.Add(new Vector2Int(xy.x, i));
                        else
                        {
                            if (dict[new Vector2Int(xy.x, i)].GetComponent<positioner>().player != player)
                                list.Add(new Vector2Int(xy.x, i));
                            break;

                        }
                    }

                    break;
                }
            default: //kmet (prva poteza, ki jo naredi, je lahko 1 ali 2 polji naprej, vsaka naslednja samo 1 naprej)
                {
                    if (player == 0)
                    {
                        if (xy.y < 7)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x, xy.y + 1)))
                                list.Add(new Vector2Int(xy.x, xy.y + 1));
                            if (xy.x > 0)
                            {
                                if (dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y + 1)) && dict[new Vector2Int(xy.x - 1, xy.y + 1)].GetComponent<positioner>().player != player)
                                    list.Add(new Vector2Int(xy.x - 1, xy.y + 1));
                            }
                            if (xy.x < 7)
                            {
                                if (dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y + 1)) && dict[new Vector2Int(xy.x + 1, xy.y + 1)].GetComponent<positioner>().player != player)
                                    list.Add(new Vector2Int(xy.x + 1, xy.y + 1));
                            }
                        }

                    }
                    else
                    {
                        if (xy.y > 0)
                        {
                            if (!dict.ContainsKey(new Vector2Int(xy.x, xy.y - 1)))
                                list.Add(new Vector2Int(xy.x, xy.y - 1));
                            if (xy.x > 0)
                            {
                                if (dict.ContainsKey(new Vector2Int(xy.x - 1, xy.y - 1)) && dict[new Vector2Int(xy.x - 1, xy.y - 1)].GetComponent<positioner>().player != player)
                                    list.Add(new Vector2Int(xy.x - 1, xy.y - 1));
                            }
                            if (xy.x < 7)
                            {
                                if (dict.ContainsKey(new Vector2Int(xy.x + 1, xy.y - 1)) && dict[new Vector2Int(xy.x + 1, xy.y - 1)].GetComponent<positioner>().player != player)
                                    list.Add(new Vector2Int(xy.x + 1, xy.y - 1));
                            }
                        }
                    }
                    break;
                }
        }
        return list;
    }

    float pulse = 0;
    void Update()
    {
        if (tileselect || swapselect)
        {
            pulse += 3.5f * Time.deltaTime;
            pulse %= 2 * (float)System.Math.PI;
            transform.localRotation = Quaternion.Euler(0f, 0f, (float)System.Math.Sin(pulse) * 20f);

        }
        else
        {
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        transform.position = new Vector3(-4.2f, -4.2f, -1) + new Vector3(xy.x * 1.2f, xy.y * 1.2f, 0f);

        //če je v tile select stanju
        //for (vsak el. v eval, na zračunanem kosu ekrana)
        //če klikne na določeno mesto spremeni dict
        //če fali skensla tile select

        if (board.GetComponent<init>().turn == player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;
                x = Camera.main.ScreenToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane)).x;
                y = Camera.main.ScreenToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane)).y;
                if (tileselect)
                {
                    Dictionary<Vector2Int, GameObject> dict = board.GetComponent<init>().dict;
                    //Debug.Log(lts(tiles));
                    for (int i = 0; i < tiles.Count; i++)
                    {
                        if (x >= -4.2f + tiles[i].x * 1.2f - 0.5f && x <= -4.2f + tiles[i].x * 1.2f + 0.5f
                         && y >= -4.2f + tiles[i].y * 1.2f - 0.5f && y <= -4.2f + tiles[i].y * 1.2f + 0.5f) //najdli tile
                        {

                            dict.Remove(xy);
                            xy = tiles[i];
                            if (dict.ContainsKey(xy))
                            { //požremo figuro
                                if (dict[xy].GetComponent<positioner>().tip == 5) board.GetComponent<init>().turn = -1 - player;
                                dict[xy].SetActive(false);
                                dict.Remove(xy);
                                if (player == 0) board.GetComponent<init>().count2--;
                                else board.GetComponent<init>().count1--;
                            }
                            dict.Add(xy, gameObject);
                            //Debug.Log("added " + xy + " -> " + dict[xy].name);
                            if (board.GetComponent<init>().turn >= 0)
                            {
                                if (UnityEngine.Random.Range(0, board.GetComponent<init>().qterate) == 0)
                                {
                                    Debug.Log("QTE");
                                    int quicktime = UnityEngine.Random.Range(0, 10);
                                    if (quicktime < 5)
                                    {
                                        qtex2.GetComponent<qtex2>().qte(board.GetComponent<init>().turn);
                                    }
                                    else if (quicktime < 8 && ((player == 0 && board.GetComponent<init>().count1 > 1) || (player == 1 && board.GetComponent<init>().count2 > 2)))
                                    {
                                        qteswap.GetComponent<qteswap>().qte(board.GetComponent<init>().turn);
                                    }
                                    else qteboom.GetComponent<qteboom>().qte(board.GetComponent<init>().turn, xy);
                                    board.GetComponent<init>().qterate = 7;
                                }
                                else board.GetComponent<init>().qterate--;
                                //Debug.Log(board.GetComponent<init>().qterate);
                                board.GetComponent<init>().turn = 1 - board.GetComponent<init>().turn;
                            }
                            Debug.Log("st p1: " + board.GetComponent<init>().count1);
                            Debug.Log("st p2: " + board.GetComponent<init>().count2);

                        }
                    }
                    tiles = new List<Vector2Int>();
                    tileselect = false;
                }
                else if (swapselect)
                {
                    int i = (int)((x + 4.7f) / 1.2);
                    int j = (int)((y + 4.7f) / 1.2);

                    Debug.Log("clicked at (" + i + ", " + j + ")");
                    Dictionary<Vector2Int, GameObject> dict = board.GetComponent<init>().dict;

                    if (dict.ContainsKey(new Vector2Int(i, j)) && dict[new Vector2Int(i, j)].GetComponent<positioner>().player == player)
                    {
                        Debug.Log("swappytime");
                        GameObject go = dict[new Vector2Int(i, j)];
                        dict.Remove(new Vector2Int(i, j));
                        dict.Remove(xy);
                        dict.Add(new Vector2Int(i, j), gameObject);
                        dict.Add(xy, go);
                        go.GetComponent<positioner>().xy = xy;
                        xy = new Vector2Int(i, j);
                        board.GetComponent<init>().swappy = false;
                        board.GetComponent<init>().turn = 1 - board.GetComponent<init>().turn;
                    }
                    swapselect = false;
                }
                else
                {
                    //Debug.Log("BLEE :P");
                    //Debug.Log("mouse coords: " + x + " " + y);
                    if (x >= -4.2f + xy.x * 1.2f - 0.5f && x <= -4.2f + xy.x * 1.2f + 0.5f
                     && y >= -4.2f + xy.y * 1.2f - 0.5f && y <= -4.2f + xy.y * 1.2f + 0.5f) //najdli tile
                    {
                        if (board.GetComponent<init>().swappy)
                        {
                            Debug.Log("swappy");
                            swapselect = true;
                        }
                        else
                        {
                            tiles = eval();
                            //Debug.Log(lts(tiles));
                            tileselect = true;
                        }

                    }
                }
            }
        }
    }

    List<Vector2Int> tiles = new List<Vector2Int>();
    void OnMouseDown()
    {
        /* if (tileselect) return;
        Debug.Log("BLEE :P");
        //če ni v tile select stanju
        if (!tileselect)
        {
            tiles = eval();
            Debug.Log(lts(tiles));
            tileselect = true;
        } */
    }
}
