using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    private List<Vector2Int> xy0 = new List<Vector2Int>{new Vector2Int(0, 0),
                                new Vector2Int(1, 0),
                                new Vector2Int(2, 0),
                                new Vector2Int(3, 0),
                                new Vector2Int(5, 0),
                                new Vector2Int(6, 0),
                                new Vector2Int(7, 0),
                                new Vector2Int(0, 1),
                                new Vector2Int(1, 1),
                                new Vector2Int(2, 1),
                                new Vector2Int(3, 1),
                                new Vector2Int(4, 1),
                                new Vector2Int(5, 1),
                                new Vector2Int(6, 1),
                                new Vector2Int(7, 1)};

    private List<Vector2Int> xy1 = new List<Vector2Int>{new Vector2Int(0, 7),
                                new Vector2Int(1, 7),
                                new Vector2Int(2, 7),
                                new Vector2Int(4, 7),
                                new Vector2Int(5, 7),
                                new Vector2Int(6, 7),
                                new Vector2Int(7, 7),
                                new Vector2Int(0, 6),
                                new Vector2Int(1, 6),
                                new Vector2Int(2, 6),
                                new Vector2Int(3, 6),
                                new Vector2Int(4, 6),
                                new Vector2Int(5, 6),
                                new Vector2Int(6, 6),
                                new Vector2Int(7, 6)};

    public GameObject kralj_1;
    public GameObject kmet1_1;
    public GameObject kmet2_1;
    public GameObject kmet3_1;
    public GameObject kmet4_1;
    public GameObject kmet5_1;
    public GameObject kmet6_1;
    public GameObject kmet7_1;
    public GameObject kmet8_1;
    public GameObject lovec1_1;
    public GameObject lovec2_1;
    public GameObject trdnjava1_1;
    public GameObject trdnjava2_1;
    public GameObject kraljica_1;
    public GameObject zmaj1_1;
    public GameObject zmaj2_1;


    public GameObject kralj_2;
    public GameObject kmet1_2;
    public GameObject kmet2_2;
    public GameObject kmet3_2;
    public GameObject kmet4_2;
    public GameObject kmet5_2;
    public GameObject kmet6_2;
    public GameObject kmet7_2;
    public GameObject kmet8_2;
    public GameObject lovec1_2;
    public GameObject lovec2_2;
    public GameObject trdnjava1_2;
    public GameObject trdnjava2_2;
    public GameObject kraljica_2;
    public GameObject zmaj1_2;
    public GameObject zmaj2_2;

    public GameObject p1;
    public GameObject p2;
    public GameObject p1w;
    public GameObject p2w;
    public GameObject r;

    public bool swappy = false;
    public int qterate = 7;
    public int turn = -3;
    public int count1 = 16;
    public int count2 = 16;
    public static string stringle(Dictionary<Vector2Int, GameObject> dict)
    {
        string stringe = "";

        foreach (KeyValuePair<Vector2Int, GameObject> entry in dict)
        {
            stringe += entry.Key + " -> " + entry.Value + "\n";
        }

        return stringe;
    }

    public Dictionary<Vector2Int, GameObject> dict = new Dictionary<Vector2Int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //positioner test = kmet1.GetComponent<positioner>();
        //Debug.Log(test.xy);
        turn = UnityEngine.Random.Range(0, 2);
        dict = new Dictionary<Vector2Int, GameObject>();
        List<GameObject> list1 = new List<GameObject>{kmet1_1, kmet2_1, kmet3_1, kmet4_1, kmet5_1, kmet6_1, kmet7_1, kmet8_1,
                                                    zmaj1_1, zmaj2_1, trdnjava1_1, trdnjava2_1, lovec1_1, lovec2_1, kraljica_1};

        List<GameObject> list2 = new List<GameObject>{kmet1_2, kmet2_2, kmet3_2, kmet4_2, kmet5_2, kmet6_2, kmet7_2, kmet8_2,
                                                    zmaj1_2, zmaj2_2, trdnjava1_2, trdnjava2_2, lovec1_2, lovec2_2, kraljica_2};

        kralj_1.SetActive(true);
        positioner p = kralj_1.GetComponent<positioner>();
        p.xy = new Vector2Int(4, 0);
        dict.Add(new Vector2Int(4, 0), kralj_1);
        kralj_2.SetActive(true);
        p = kralj_2.GetComponent<positioner>();
        p.xy = new Vector2Int(3, 7);
        dict.Add(new Vector2Int(3, 7), kralj_2);

        int i;
        for (int k = 0; k < list1.Count; k++)
        {
            list1[k].SetActive(true);
            p = list1[k].GetComponent<positioner>();
            i = UnityEngine.Random.Range(0, xy0.Count);
            //Debug.Log(i);
            p.xy = xy0[i];
            dict.Add(xy0[i], list1[k]);
            //Debug.Log("added " + p.xy + " -> " + dict[p.xy].name);
            xy0.RemoveAt(i);
        }


        for (int k = 0; k < list2.Count; k++)
        {
            list2[k].SetActive(true);
            p = list2[k].GetComponent<positioner>();
            i = UnityEngine.Random.Range(0, xy1.Count);
            //Debug.Log(i);
            p.xy = xy1[i];
            dict.Add(xy1[i], list2[k]);
            //Debug.Log("added " + p.xy + " -> " + dict[p.xy].name);
            xy1.RemoveAt(i);
        }
        //Debug.Log(dict.Count);
    }

    public void reboot()
    {
        List<Vector2Int> xy0 = new List<Vector2Int>{new Vector2Int(0, 0),
                                new Vector2Int(1, 0),
                                new Vector2Int(2, 0),
                                new Vector2Int(3, 0),
                                new Vector2Int(5, 0),
                                new Vector2Int(6, 0),
                                new Vector2Int(7, 0),
                                new Vector2Int(0, 1),
                                new Vector2Int(1, 1),
                                new Vector2Int(2, 1),
                                new Vector2Int(3, 1),
                                new Vector2Int(4, 1),
                                new Vector2Int(5, 1),
                                new Vector2Int(6, 1),
                                new Vector2Int(7, 1)};

        List<Vector2Int> xy1 = new List<Vector2Int>{new Vector2Int(0, 7),
                                new Vector2Int(1, 7),
                                new Vector2Int(2, 7),
                                new Vector2Int(4, 7),
                                new Vector2Int(5, 7),
                                new Vector2Int(6, 7),
                                new Vector2Int(7, 7),
                                new Vector2Int(0, 6),
                                new Vector2Int(1, 6),
                                new Vector2Int(2, 6),
                                new Vector2Int(3, 6),
                                new Vector2Int(4, 6),
                                new Vector2Int(5, 6),
                                new Vector2Int(6, 6),
                                new Vector2Int(7, 6)};
        //positioner test = kmet1.GetComponent<positioner>();
        //Debug.Log(test.xy);
        turn = UnityEngine.Random.Range(0, 2);
        dict = new Dictionary<Vector2Int, GameObject>();
        List<GameObject> list1 = new List<GameObject>{kmet1_1, kmet2_1, kmet3_1, kmet4_1, kmet5_1, kmet6_1, kmet7_1, kmet8_1,
                                                    zmaj1_1, zmaj2_1, trdnjava1_1, trdnjava2_1, lovec1_1, lovec2_1, kraljica_1};

        List<GameObject> list2 = new List<GameObject>{kmet1_2, kmet2_2, kmet3_2, kmet4_2, kmet5_2, kmet6_2, kmet7_2, kmet8_2,
                                                    zmaj1_2, zmaj2_2, trdnjava1_2, trdnjava2_2, lovec1_2, lovec2_2, kraljica_2};

        kralj_1.SetActive(true);
        positioner p = kralj_1.GetComponent<positioner>();
        p.xy = new Vector2Int(4, 0);
        dict.Add(new Vector2Int(4, 0), kralj_1);
        kralj_2.SetActive(true);
        p = kralj_2.GetComponent<positioner>();
        p.xy = new Vector2Int(3, 7);
        dict.Add(new Vector2Int(3, 7), kralj_2);

        int i;
        for (int k = 0; k < list1.Count; k++)
        {
            list1[k].SetActive(true);
            p = list1[k].GetComponent<positioner>();
            i = UnityEngine.Random.Range(0, xy0.Count);
            //Debug.Log(i);
            p.xy = xy0[i];
            dict.Add(xy0[i], list1[k]);
            //Debug.Log("added " + p.xy + " -> " + dict[p.xy].name);
            xy0.RemoveAt(i);
        }


        for (int k = 0; k < list2.Count; k++)
        {
            list2[k].SetActive(true);
            p = list2[k].GetComponent<positioner>();
            i = UnityEngine.Random.Range(0, xy1.Count);
            //Debug.Log(i);
            p.xy = xy1[i];
            dict.Add(xy1[i], list2[k]);
            //Debug.Log("added " + p.xy + " -> " + dict[p.xy].name);
            xy1.RemoveAt(i);
        }
        //Debug.Log(dict.Count);
    }


    // Update is called once per frame
    void Update()
    {
        if (p1.GetComponent<view>().pogoj == turn)
        {
            p1.SetActive(true);
        }
        else p1.SetActive(false);

        if (p1w.GetComponent<view>().pogoj == turn)
        {
            p1w.SetActive(true);
        }
        else p1w.SetActive(false);

        if (p2.GetComponent<view>().pogoj == turn)
        {
            p2.SetActive(true);
        }
        else p2.SetActive(false);

        if (p2w.GetComponent<view>().pogoj == turn)
        {
            p2w.SetActive(true);
        }
        else p2w.SetActive(false);

        if (turn < 0)
        {
            r.SetActive(true);
        }
        else r.SetActive(false);
    }
}
