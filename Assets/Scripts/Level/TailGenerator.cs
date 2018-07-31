using System.Linq;
using System.Collections.Generic;
using UnityEngine;

static class BaseGenrator
{

    private static Dictionary<BaseElement, HashSet<int>> _hashtableBases;

    static BaseGenrator()
    {
        int d1 = Constants.BASE1A_PROBOBILITY + Constants.BASE1B_PROBOBILITY, d2 = d1 + Constants.BASE2_PROBOBILITY, d3 = d2 + Constants.BASE3A_PROBOBILITY;
        _hashtableBases = new Dictionary<BaseElement, HashSet<int>>()
        {
            { new Base1a(), new HashSet<int>(Enumerable.Range(0, Constants.BASE1A_PROBOBILITY))},
            { new Base1b(), new HashSet<int>(Enumerable.Range(Constants.BASE1A_PROBOBILITY, Constants.BASE1B_PROBOBILITY))},
            { new Base2(), new HashSet<int>(Enumerable.Range(d1, Constants.BASE2_PROBOBILITY))},
            { new Base3a(), new HashSet<int>(Enumerable.Range(d2, Constants.BASE3A_PROBOBILITY))},
            { new Base3b(), new HashSet<int>(Enumerable.Range(d3, Constants.BASE3B_PROBOBILITY))},
        };
    }

    private static BaseElement GenerateBase()
    {
        int value = Random.Range(0, 100);
        BaseElement el = null;
        foreach (KeyValuePair<BaseElement, HashSet<int>> pair in _hashtableBases)
        {
            if (pair.Value.Contains(value))
            {
                el = pair.Key;
                break;
            }   
        }
        return el;
    }

    private static void GenereateCorridor(Offset offset)
    {
        int d1 = Constants.CORRIDOR1A_PROBOBILITY + Constants.CORRIDOR1B_PROBOBILITY, d2 = d1 + Constants.CORRIDOR1C_PROBOBILITY, d3 = d2 + Constants.CORRIDOR2A_PROBOBILITY;
        int value = Random.Range(0, 100);
        Vector3 vector = new Vector3(offset.X, offset.Y, 0f);
        GameObject instance;
        if (Enumerable.Range(0, Constants.CORRIDOR1A_PROBOBILITY).Contains(value))
        {
            instance = Object.Instantiate(TailGenerator.corridor1a, vector, Quaternion.identity);
            offset.ChangeOffset(0, 3);
        }
        if (Enumerable.Range(Constants.CORRIDOR1A_PROBOBILITY, Constants.CORRIDOR1B_PROBOBILITY).Contains(value))
        {
            instance = Object.Instantiate(TailGenerator.corridor1b, vector, Quaternion.identity);
            offset.ChangeOffset(0, 3);
        }
        if (Enumerable.Range(d1, Constants.CORRIDOR1C_PROBOBILITY).Contains(value))
        {
            instance = Object.Instantiate(TailGenerator.corridor1c, vector, Quaternion.identity);
            offset.ChangeOffset(0, 3);
        }
        if (Enumerable.Range(d2, Constants.CORRIDOR2A_PROBOBILITY).Contains(value))
        {
            instance = Object.Instantiate(TailGenerator.corridor2a, vector, Quaternion.identity);
            offset.ChangeOffset(0, 4);
        }
        if (Enumerable.Range(d3, Constants.CORRIDOR2B_PROBOBILITY).Contains(value))
        {
            instance = Object.Instantiate(TailGenerator.corridor2a, vector, Quaternion.identity);
            offset.ChangeOffset(1, 4);
        }
    }

    public static void GenerateTail(ref Offset offset, int distance, ref bool flag)
    {
        if (flag)
        {
            GenereateCorridor(offset);
            flag = false;
        }
        else
        {
            GenerateBase().MakeInstance(distance, offset);
            flag = true;
        }
    }
}

public class Coordinates
{
    public int x;
    public int y;

    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Offset
{
    private Coordinates _coordinates;

    public Offset(Coordinates coordinates) => _coordinates = coordinates;

    public int X
    {
        get
        { return _coordinates.x; }
    }

    public int Y
    {
        get
        { return _coordinates.y; }
    }

    public void ChangeOffset(int x, int y)
    {
        _coordinates.x += x;
        _coordinates.y += y;
    }
}

public class TailGenerator : MonoBehaviour {
    public static GameObject base1a { get; }
    public static GameObject base1b { get; }
    public static GameObject base2 { get; }
    public static GameObject base3a { get; }
    public static GameObject base3b { get; }
    public static GameObject corridor1a { get; }
    public static GameObject corridor1b { get; }
    public static GameObject corridor1c { get; }
    public static GameObject corridor2a { get; }
    public static GameObject corridor2b { get; }
    public static GameObject coin { get; }
    public static GameObject trap { get; }

    private Transform fieldHolder;
    private int tailsCount = 3;
    private bool flag = true;
    private Offset offset = new Offset(new Coordinates(0, 0));
    // Use this for initialization
    public void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int distance = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().distanceMax;
        if (distance % 4 == 0 && distance / 3 >= tailsCount - 1)
        {
            BaseGenrator.GenerateTail(ref offset, distance, ref flag);
            tailsCount++;
        }
    }
}
