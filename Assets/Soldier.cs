using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    [SerializeField]
    private int limit = 20;
    private List<string> military = new List<string>(20);
    private Dictionary<int,string> manual = new Dictionary<int,string>(20);
    private string[,] classroom = new string[4, 5];
    private Stack<string> cave = new Stack<string>(20);

	// Use this for initialization
	void Start () {

        InitMilitary();
        InitManaul();
        CallPerson();
        IntoClassroom();
        ShowClassroom();
        IntoCave();
        ExitCave();
        ShowMilitary();
    }

    void InitMilitary()
    {
        // first person is "A", second person is "B" and so on......
        for (int i = 0; i < limit; ++i)
            military.Add( System.Convert.ToChar(i+ 'A').ToString());
    }

    void InitManaul()
    {
        for (int i = 0; i < limit; ++i) 
            manual.Add(i+1,military[i]);
    }

    void CallPerson()
    {
        int r = Random.Range(1,20);
        Debug.Log("Person id is " + r + " and name is " + military[r - 1]);
    }

    void IntoClassroom()
    {
        for (int x = 0; x < 4; ++x)
            for (int y = 0; y < 5; ++y)
                classroom[x, y] = military[ x * 5 + y ];
    }

    void IntoCave()
    {
        for (int i = 0; i < limit; ++i)
            cave.Push(military[i]);
    }

    void ExitCave()
    {
        for (int i = 0; i < limit; ++i)
            military[i] = cave.Pop();
    }

    void ShowMilitary()
    {
        for (int i = 0; i < limit; ++i)
            Debug.Log("Order "+(i+1)+" is :"+military[i]);
    }

    void ShowClassroom()
    {
        for (int x = 0; x < 4; ++x)
            for (int y = 0; y < 5; ++y)
                Debug.Log("classroom("+x+","+y+"):"+classroom[x, y]) ;
    }
}
