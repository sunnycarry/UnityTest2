using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float MachineCompute<T, U>(T box);

public delegate float MachineEasyCompute<T>(Box<T> box) where T : Fruit;

public delegate void Print(int value);

public class Printer2 {
    
    public void PrintNum(int num, Print p)
    {
        p(num);
    }

}

public class Printer1
{
    public void PrintNormal(int num)
    { Debug.Log("normal = "+ num); }
    public void Printx10(int num)
    {
        Debug.Log("multi 10 = "+num * 10);
    }

}


public class Advance : MonoBehaviour
{
    private void Start()
    {
        Machine m = new Machine();

        Printer1 p1 = new Printer1();
        Printer2 p2 = new Printer2();
        p2.PrintNum(10, p1.Printx10);
        p2.PrintNum(10, p1.PrintNormal);
        



        Box<Banana> b_box = new Box<Banana>();
        Box<Pineapple> p_box = new Box<Pineapple>();
        Box<Guava> g_box = new Box<Guava>();
        Box<Apple> a_box = new Box<Apple>();
        Box<Mango> m_box = new Box<Mango>();
        Banana b = new Banana(b_box);
        Banana b2 = new Banana(b_box);
        Banana b3 = new Banana(b_box);
        Apple a = new Apple(a_box);
        Apple a2 = new Apple(a_box);

        // float total_sum = 0;
        // float wtf = 0;
        float easy_total = 0;
        // more easier computing
        easy_total += m.EasyCompute<Banana>(m.EasyGetWeight<Banana>, b_box);
        easy_total += m.EasyCompute<Pineapple>(m.EasyGetWeight<Pineapple>, p_box);
        easy_total += m.EasyCompute<Guava>(m.EasyGetWeight<Guava>, g_box);
        easy_total += m.EasyCompute<Apple>(m.EasyGetWeight<Apple>, a_box);
        easy_total += m.EasyCompute<Mango>(m.EasyGetWeight<Mango>, m_box);
        Debug.Log("total sum is :  " + easy_total);

        /*
        // wtf
        wtf += m.real_compute<Box<Banana>,Banana>(m.ComputeWeight<Box<Banana>, Banana>,b_box);
        wtf += m.real_compute<Box<Pineapple>, Pineapple>(m.ComputeWeight<Box<Pineapple>, Pineapple>, p_box);
        wtf += m.real_compute<Box<Guava>, Guava>(m.ComputeWeight<Box<Guava>, Guava>, g_box);
        wtf += m.real_compute<Box<Apple>, Apple>(m.ComputeWeight<Box<Apple>, Apple>, a_box);    
        wtf += m.real_compute<Box<Mango>, Mango>(m.ComputeWeight<Box<Mango>, Mango>, m_box);
        Debug.Log("WTF is this " + wtf);
        total_sum += m.ComputeWeight<Box<Banana>, Banana>(b_box);
        total_sum += m.ComputeWeight<Box<Pineapple>, Pineapple>(p_box);
        total_sum += m.ComputeWeight<Box<Guava>, Guava>(g_box);
        total_sum += m.ComputeWeight<Box<Apple>, Apple>(a_box);
        total_sum += m.ComputeWeight<Box<Mango>, Mango>(m_box);
        Debug.Log(total_sum);
        */

        //Debug.Log(b_box.GetBoxWeight());
        //Debug.Log("total amount = " + m.Compute());
    }
}



public class Machine
{
    /*
    // this is too complex , please see function "EasyCompute"
    public float real_compute<T,U>(MachineCompute<T,U> m,T b) where T:Box<U>
    {

        // when declaring delegate function "MachineCompute" we need to pass a (T box) , now T = Box<U>
        // so b can be passed into m => m(b);
        // In main function we can pass "ComputeWeight"(below) to "MachineCompute" 
        // bcz their parameter type(Box<U>) and function return type(float) are the same
        return m(b); 
        // if we have lots of computing funtcion such as : compute value
        // All of them need to pass the same parameter(box<fruit>,fruit)
        // we can still use this "real_compute" to recieve different function if had same parameter type
        // for example:real_compute< Box_type, Fruit >(ComputeValue < Box_type, Fruit>);
    }

    public float ComputeWeight<T,U>(T box) where T: Box<U>
    {
        float box_weight = box.box_weight;

        Debug.Log("Start to compute");

        return box_weight;  

    }
    */
    public float EasyCompute<T>(MachineEasyCompute<T> m, Box<T> b) where T: Fruit
    {
        return m(b);
    }

    public float EasyGetWeight<T>(Box<T> box) where T:Fruit
    {
        float box_weight = box.box_weight;
        return box_weight;
    }
}


public class Box<T> where T:Fruit
{
    const int limit = 5;
    public float box_weight = 0;
    public int cnt = 0;
    public List<T> fruit_box;
    public Box()
    {
        cnt = 0;
        box_weight = 0;
        fruit_box = new List<T>();

    }

    public void add(T fruit, float w)
    {
        if (cnt < limit)
        {
            box_weight += w;
            cnt++;
            fruit_box.Add(fruit);
        }
        else
            Debug.Log("this box is full");
    }

    public float ComputeBoxWeight()
    {
        float sum = 0;
        for (int i = 0; i < limit; ++i)
            sum += fruit_box[i].weight;
        return sum;
    }
}

public class Fruit
{
    public Fruit( ) { }
    public float weight;
    public float getweight()
    {
        return weight;
    }
}

public class Banana : Fruit
{
    public Banana() : base() { weight = 200; }
    public Banana(Box<Banana> b)
    {
        weight = 200;
        b.add(this,weight);
        
    }
}

public class Pineapple : Fruit
{
    public Pineapple() : base() { weight = 2000; }
    public Pineapple(Box<Pineapple> b)
    {
        weight = 2000;
        b.add(this, weight);
    }
}

public class Guava : Fruit
{
    public Guava() : base() { weight = 300; }
    public Guava(Box<Guava> b)
    {
        weight = 300;
        b.add(this, weight);
    }
}

public class Apple : Fruit
{
    public Apple() : base() { weight = 250; }
    public Apple(Box<Apple> b)
    {
        weight = 250;
        b.add(this, weight);
    }
}

public class Mango : Fruit
{
    public Mango() : base() { weight = 600; }
    public Mango(Box<Mango> b)
    {
        weight = 600;
        b.add(this, weight);
    }
}



