using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Printer
{
    void print(string s);
}

public abstract class Shape : Printer
{
    public enum Ty { Tri_S, Cir_S };
    public string ty;
    public abstract void print(string s);

}

public class Triangle : Shape
{
    private float _height, _width;

    public float height
    {
        get { return _height; }
        set { _height = value; }
    }

    public float width
    {
        get { return _width; }
        set { _width = value; }
    }

    public override void print(string s)
    {
        Debug.Log("triangle print : " + s);
        ty = Ty.Tri_S.ToString();
        Debug.Log("shape = " + ty);
    }
}

public class Circle : Shape
{
    public override void print(string s)
    {
        Debug.Log("circle print : " + s);
        ty = Ty.Cir_S.ToString();
        Debug.Log("shape = " + ty);
    }

    public float getArea(int r)
    {
        return Mathf.PI * r * r;
    }
}

