using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDictHash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> numbers = new List<int>();
        numbers.Add(11);
        numbers.Add(12);
        numbers.Insert(0, 10);
        numbers.RemoveAt(2);

        foreach (int number in numbers)
        {
            Debug.Log(number);
        }

        Debug.Log(numbers.Capacity);
        Debug.Log(numbers.Count);


        //Dictionary

        AgeTracker ageTracker = new AgeTracker();

        ageTracker.AddAge("John", 25);
        Debug.Log(ageTracker.GetAge("John"));

        //Hashset

        HashSet<string> hashSet = new HashSet<string>();
        hashSet.Add("Sadee");
        hashSet.Add("KD");

        bool containsKD = hashSet.Contains("KD");
        Debug.Log("Contains KD " + containsKD);
    }
}

class AgeTracker
{
    private Dictionary<string, int> ages;

    public AgeTracker()
    {
        ages = new Dictionary<string, int>();
    }

    public void AddAge(string name, int age)
    {
        ages.Add(name,age);
    }
    public int GetAge(string name)
    {
        return ages[name];
    }
}


