using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataStructure : MonoBehaviour {

    int[] arr;
    List<int> l = new List<int>();
    Stack<string> s = new Stack<string>();
    Dictionary<string, int> d = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
        PutIntoArray();
        SortAndThrow();
        PutIntoStack();
        CreateDictionary();
    }

    void PutIntoArray()
    {
        arr = new int[] { 8, 5, 4, 9, 6, 3, 1, 2, 7 };
    }

    void SortAndThrow()
    {
        System.Array.Sort(arr);
        for (int i = 0; i < arr.Length; ++i)
            l.Add(arr[i]);
    }

    void PutIntoStack()
    {
        s.Push("a");
        s.Push("b");
        s.Push("c");
        s.Push("d");
        s.Push("e");
        s.Push("f");
        s.Push("g");
        s.Push("h");
        s.Push("i");
        s.Push("j");
    }

    void CreateDictionary()
    {
        int s_size = s.Count();
        for (int i = 0; i < s_size; ++i)
            d.Add(s.Pop(), i + 1);
    }
}
