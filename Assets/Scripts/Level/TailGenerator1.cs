using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class CoinProb
{
    const int coinProb = 20;
    private bool[] p = new bool[100];
    public CoinProb(int factor)
    {
        for (int i = 0; i < coinProb + factor; i++)
            p[i] = true;
        for (int i = coinProb + factor; i < 100; i++)
            p[i] = false;
    }
    public bool isCoin()
    {
        return p[Random.Range(0, 100)];
    }
}

public class TrapProb
{
    const int trapProb = 30;
    private bool[] p = new bool[100];
    public TrapProb(int factor)
    {
        for (int i = 0; i < trapProb + factor; i++)
            p[i] = true;
        for (int i = trapProb + factor; i < 100; i++)
            p[i] = false;
    }
    public bool isTrap()
    {
        return p[Random.Range(0, 100)];
    }
}

public class Offset
{
    public int x;
    public int y;
    public bool flag;

    public Offset(int x, int y)
    {
        SetOffset(x, y);
        flag = false;
    }

    public void SetOffset(int x, int y)
    {
        this.x += x;
        this.y += y;
    }
}

static class TailFactory
{
    private static int[] base_p = new int[100];
    private static int[] corridor_p = new int[100];
    private static void BaseP()
    {
        for (int i = 0; i < 16; i++)
        {
            base_p[i] = 0;
        }
        for (int i = 16; i < 32; i++)
        {
            base_p[i] = 1;
        }
        for (int i = 32; i < 66; i++)
        {
            base_p[i] = 2;
        }
        for (int i = 66; i < 82; i++)
        {
            base_p[i] = 3;
        }
        for (int i = 82; i < 100; i++)
        {
            base_p[i] = 4;
        }
    }
    private static void CorridorP()
    {
        for (int i = 0; i < 16; i++)
        {
            corridor_p[i] = 0;
        }
        for (int i = 16; i < 32; i++)
        {
            corridor_p[i] = 1;
        }
        for (int i = 32; i < 50; i++)
        {
            corridor_p[i] = 2;
        }
        for (int i = 50; i < 75; i++)
        {
            corridor_p[i] = 3;
        }
        for (int i = 75; i < 100; i++)
        {
            corridor_p[i] = 4;
        }
    }
    static TailFactory()
    {
        BaseP();
        CorridorP();
    }
    public static int GetBaseTail()
    {
        return base_p[UnityEngine.Random.Range(0, 100)];
    }
    public static int GetCorridorTail()
    {
        return corridor_p[UnityEngine.Random.Range(0, 100)];
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

static class CoordinateLister
{
    public static List<Coordinates> MakeCoinCordinates(int baseID, Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.x;
        int y = offset.y;
        switch (baseID)
        {
            case 0:
                coordinates.Add(new Coordinates(x, y + 3));
                x = x - 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        coordinates.Add(new Coordinates(j + x, i + y));
                    }
                }
                return coordinates;
            case 1:
                coordinates.Add(new Coordinates(x, y + 3));
                coordinates.Add(new Coordinates(x-2, y + 1));
                coordinates.Add(new Coordinates(x + 2, y + 1));
                x = x - 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        coordinates.Add(new Coordinates(j + x, i + y));
                    }
                }
                return coordinates;
            case 2:
                coordinates.Add(new Coordinates(x + 2, y));
                coordinates.Add(new Coordinates(x - 2, y));
                coordinates.Add(new Coordinates(x + 1, y+1));
                coordinates.Add(new Coordinates(x - 1, y+1));
                coordinates.Add(new Coordinates(x + 1, y + 3));
                coordinates.Add(new Coordinates(x - 1, y + 3));
                return coordinates;
            case 3:
                coordinates.Add(new Coordinates(x + 1, y));
                coordinates.Add(new Coordinates(x - 1, y));
                coordinates.Add(new Coordinates(x + 1, y+2));
                coordinates.Add(new Coordinates(x - 1, y+2));
                return coordinates;
            default:
                coordinates.Add(new Coordinates(x + 2, y));
                coordinates.Add(new Coordinates(x - 2, y));
                coordinates.Add(new Coordinates(x + 2, y+1));
                coordinates.Add(new Coordinates(x - 2, y+1));
                coordinates.Add(new Coordinates(x + 2, y+2));
                coordinates.Add(new Coordinates(x - 2, y+2));
                coordinates.Add(new Coordinates(x + 1, y + 2));
                coordinates.Add(new Coordinates(x - 1, y + 2));
                coordinates.Add(new Coordinates(x, y + 2));
                return coordinates;
        }
    }

    public static List<Coordinates> MakeTrapCordinates(int baseID, Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.x;
        int y = offset.y;
        switch (baseID)
        {
            case 0:
                coordinates.Add(new Coordinates(x, y + 1));
                coordinates.Add(new Coordinates(x, y + 3));
                break;
            case 1:
                coordinates.Add(new Coordinates(x, y + 1));
                coordinates.Add(new Coordinates(x, y + 3));
                break;
            case 2:
                coordinates.Add(new Coordinates(x, y + 1));
                coordinates.Add(new Coordinates(x, y + 2));
                coordinates.Add(new Coordinates(x, y + 3));
                break;
            case 3:
                coordinates.Add(new Coordinates(x, y + 1));
                coordinates.Add(new Coordinates(x, y + 2));
                coordinates.Add(new Coordinates(x, y + 3));
                break;
            default:
                coordinates.Add(new Coordinates(x, y + 1));
                coordinates.Add(new Coordinates(x+2, y + 1));
                coordinates.Add(new Coordinates(x - 2, y + 1));
                coordinates.Add(new Coordinates(x, y + 2));
                coordinates.Add(new Coordinates(x, y + 3));
                break;
        }
        return coordinates;
    }
}

public class TailGenerator1 : MonoBehaviour
{

    public GameObject Base1a;
    public GameObject Base1b;
    public GameObject Base2;
    public GameObject Base3a;
    public GameObject Base3b;
    public GameObject Corridor1a;
    public GameObject Corridor1b;
    public GameObject Corridor1c;
    public GameObject Corridor2a;
    public GameObject Corridor2b;
    public GameObject Coin;
    public GameObject Trap;

    const int trapProb = 10;

    private Transform fieldHolder;
    private int tailsCount = 3;
    private Offset offset = new Offset(0, 0);

    public static class CoinGenerator
    {
        public static void GenerateCoin(int TailID, Offset offset, int distance, GameObject coin)
        {
            List<Coordinates> list = CoordinateLister.MakeCoinCordinates(TailID, offset);
            int size = list.Count;
            for (int i = 0; i < (int)Mathf.Log(distance, 2f) + 1; i++)
            {
                if (size != 0)
                {
                    int index = Random.Range(0, size);
                    GameObject instance = Instantiate(coin, new Vector3(list[index].x, list[index].y, 0f), Quaternion.identity);
                    list.Remove(list[index]);
                    size--;
                }
            }
        }
    }

    public static class TrapGenerator
    {
        public static void GenerateTrap(int TailID, Offset offset, int distance, GameObject trap)
        {
            List<Coordinates> list = CoordinateLister.MakeTrapCordinates(TailID, offset);
            int size = list.Count;
            for(int i = 0; i < distance / 50 + 1; i++)
            {
                if (size != 0)
                {
                    int index = Random.Range(0, size);
                    GameObject instance = Instantiate(trap, new Vector3(list[index].x, list[index].y, 0.001f), Quaternion.identity);
                    list.Remove(list[index]);
                    size--;
                }
            }
        }
    }
    
    private void GenerateTail(int distance)
    {
        fieldHolder = new GameObject("Field").transform;
        GameObject instance;
        if (!offset.flag)
        {
            switch (TailFactory.GetBaseTail())
            {
                case 0:
                    instance = Instantiate(Base1a, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    CoinGenerator.GenerateCoin(0, offset,  distance, Coin);
                    TrapGenerator.GenerateTrap(0, offset, distance, Trap);
                    break;
                case 1:
                    instance = Instantiate(Base1b, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    CoinGenerator.GenerateCoin(1, offset, distance, Coin);
                    TrapGenerator.GenerateTrap(1, offset, distance, Trap);
                    break;
                case 2:
                    instance = Instantiate(Base2, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    CoinGenerator.GenerateCoin(2, offset, distance, Coin);
                    TrapGenerator.GenerateTrap(2, offset, distance, Trap);
                    break;
                case 3:
                    instance = Instantiate(Base3a, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    CoinGenerator.GenerateCoin(3, offset, distance, Coin);
                    TrapGenerator.GenerateTrap(3, offset, distance, Trap);
                    break;
                default:
                    instance = Instantiate(Base3b, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    CoinGenerator.GenerateCoin(4, offset, distance, Coin);
                    TrapGenerator.GenerateTrap(4, offset, distance, Trap);
                    break;
            }
            instance.transform.SetParent(fieldHolder);
            offset.SetOffset(0, 4);
            offset.flag = true;
        }
        else
        {
            switch (TailFactory.GetCorridorTail())
            {
                case 0:
                    instance = Instantiate(Corridor1a, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    offset.SetOffset(0, 3);
                    break;
                case 1:
                    instance = Instantiate(Corridor1b, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    offset.SetOffset(0, 3);
                    break;
                case 2:
                    instance = Instantiate(Corridor1c, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    offset.SetOffset(0, 3);
                    break;
                case 3:
                    instance = Instantiate(Corridor2a, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    offset.SetOffset(0, 4);
                    break;
                default:
                    instance = Instantiate(Corridor2b, new Vector3(offset.x, offset.y, 0f), Quaternion.identity) as GameObject;
                    offset.SetOffset(1, 4);
                    break;
            }
            offset.flag = false;
        }
    }

    // Use this for initialization
    public void Start() { 
        GenerateTail(0);
        GameObject a =  Instantiate(Trap, new Vector3(0, 5, 0.001f), Quaternion.identity) as GameObject;
        GenerateTail(0);
        GenerateTail(0);
    }

    public void Update()
    {
        int distance = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().distanceMax;
        if (distance % 4 == 0 && distance / 3 >= tailsCount -1 ) { 
            GenerateTail(distance);
            tailsCount++;
        }
    }

}
*/
