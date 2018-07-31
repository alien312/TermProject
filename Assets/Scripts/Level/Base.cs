using System.Collections.Generic;
using UnityEngine;

public class CoinProb
{
    private bool[] p = new bool[100];
    public CoinProb(int factor)
    {
        for (int i = 0; i < Constants.COINT_PROBOBILITY + factor; i++)
            p[i] = true;
        for (int i = Constants.COINT_PROBOBILITY + factor; i < 100; i++)
            p[i] = false;
    }
    public bool isCoin()
    {
        return p[Random.Range(0, 100)];
    }
}

public class TrapProb
{
    private bool[] p = new bool[100];
    public TrapProb(int factor)
    {
        for (int i = 0; i < Constants.TRAP_PROBOBILITY + factor; i++)
            p[i] = true;
        for (int i = Constants.TRAP_PROBOBILITY + factor; i < 100; i++)
            p[i] = false;
    }
    public bool isTrap()
    {
        return p[Random.Range(0, 100)];
    }
}

public abstract class BaseElement{

    protected void GenerateCoins(int distance, Offset offset)
    {
        List<Coordinates> list = GenerateCoinsCoordinates(offset);
        int size = list.Count;
        for (int i = 0; i < (int)Mathf.Log(distance, 2f) + 1; i++)
        {
            if (size != 0)
            {
                int index = Random.Range(0, size);
                GameObject instance = Object.Instantiate(TailGenerator.coin, new Vector3(list[index].x, list[index].y, 0f), Quaternion.identity);
                list.Remove(list[index]);
                size--;
            }
        }
    }

    protected void GenerateTraps(int distance, Offset offset)
    {
        List<Coordinates> list = GenerateTrapsCoordinates(offset);
        int size = list.Count;
        for (int i = 0; i < distance / 50 + 1; i++)
        {
            if (size != 0)
            {
                int index = Random.Range(0, size);
                GameObject instance = Object.Instantiate(TailGenerator.trap, new Vector3(list[index].x, list[index].y, 0.001f), Quaternion.identity);
                list.Remove(list[index]);
                size--;
            }
        }
    }

    protected abstract List<Coordinates> GenerateTrapsCoordinates(Offset offset);

    protected abstract List<Coordinates> GenerateCoinsCoordinates(Offset offset);

    public virtual void MakeInstance(int distance, Offset offset)
    {
        GenerateCoins(distance, offset);
        GenerateTraps(distance, offset);
        offset.ChangeOffset(0, 4);
    }
}

public class Base1a : BaseElement
{
    protected override List<Coordinates> GenerateCoinsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
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
    }

    protected override List<Coordinates> GenerateTrapsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 1));
        coordinates.Add(new Coordinates(x, y + 3));
        return coordinates;
    }

    public override void MakeInstance(int distance, Offset offset)
    {
        GameObject instance  = Object.Instantiate(TailGenerator.base1a, new Vector3(offset.X, offset.Y, 0f), Quaternion.identity) as GameObject;
        base.MakeInstance(distance, offset);
    }
}

public class Base1b : BaseElement
{
    protected override List<Coordinates> GenerateCoinsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 3));
        coordinates.Add(new Coordinates(x - 2, y + 1));
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
    }

    protected override List<Coordinates> GenerateTrapsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 1));
        coordinates.Add(new Coordinates(x, y + 3));
        return coordinates;
    }

    public override void MakeInstance(int distance, Offset offset)
    {
        GameObject instance = Object.Instantiate(TailGenerator.base1b, new Vector3(offset.X, offset.Y, 0f), Quaternion.identity) as GameObject;
        base.MakeInstance(distance, offset);
    }
}

public class Base2 : BaseElement
{
    protected override List<Coordinates> GenerateCoinsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x + 2, y));
        coordinates.Add(new Coordinates(x - 2, y));
        coordinates.Add(new Coordinates(x + 1, y + 1));
        coordinates.Add(new Coordinates(x - 1, y + 1));
        coordinates.Add(new Coordinates(x + 1, y + 3));
        coordinates.Add(new Coordinates(x - 1, y + 3));
        return coordinates;
    }

    protected override List<Coordinates> GenerateTrapsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 1));
        coordinates.Add(new Coordinates(x, y + 2));
        coordinates.Add(new Coordinates(x, y + 3));
        return coordinates;
    }

    public override void MakeInstance(int distance, Offset offset)
    {
        GameObject instance = Object.Instantiate(TailGenerator.base2, new Vector3(offset.X, offset.Y, 0f), Quaternion.identity) as GameObject;
        base.MakeInstance(distance, offset);
    }
}

public class Base3a : BaseElement
{ 
    protected override List<Coordinates> GenerateCoinsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x + 1, y));
        coordinates.Add(new Coordinates(x - 1, y));
        coordinates.Add(new Coordinates(x + 1, y + 2));
        coordinates.Add(new Coordinates(x - 1, y + 2));
        return coordinates;
    }

    protected override List<Coordinates> GenerateTrapsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 1));
        coordinates.Add(new Coordinates(x, y + 2));
        coordinates.Add(new Coordinates(x, y + 3));
        return coordinates;
    }

    public override void MakeInstance(int distance, Offset offset)
    {
        GameObject instance = Object.Instantiate(TailGenerator.base3a, new Vector3(offset.X, offset.Y, 0f), Quaternion.identity) as GameObject;
        base.MakeInstance(distance, offset);
    }
}

public class Base3b : BaseElement
{
    protected override List<Coordinates> GenerateCoinsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x + 2, y));
        coordinates.Add(new Coordinates(x - 2, y));
        coordinates.Add(new Coordinates(x + 2, y + 1));
        coordinates.Add(new Coordinates(x - 2, y + 1));
        coordinates.Add(new Coordinates(x + 2, y + 2));
        coordinates.Add(new Coordinates(x - 2, y + 2));
        coordinates.Add(new Coordinates(x + 1, y + 2));
        coordinates.Add(new Coordinates(x - 1, y + 2));
        coordinates.Add(new Coordinates(x, y + 2));
        return coordinates;
    }

    protected override List<Coordinates> GenerateTrapsCoordinates(Offset offset)
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        int x = offset.X;
        int y = offset.Y;
        coordinates.Add(new Coordinates(x, y + 1));
        coordinates.Add(new Coordinates(x + 2, y + 1));
        coordinates.Add(new Coordinates(x - 2, y + 1));
        coordinates.Add(new Coordinates(x, y + 2));
        coordinates.Add(new Coordinates(x, y + 3));
        return coordinates;
    }

    public override void MakeInstance(int distance, Offset offset)
    {
        GameObject instance = Object.Instantiate(TailGenerator.base3b, new Vector3(offset.X, offset.Y, 0f), Quaternion.identity) as GameObject;
        base.MakeInstance(distance, offset);
    }
}

