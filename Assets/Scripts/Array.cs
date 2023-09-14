using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] fruits = new string[3];
        fruits[0]= "apple";
        fruits[1]= "banana";
        fruits[0]= "grapes";
        foreach (string fruit in fruits)
        {
            Debug.Log(fruit);
        }
		
        string[] animals = { "Dog", "Fox", "Deer" };
        animals[2]= "Doe";
        foreach (string animal in animals)
        {
            Debug.Log(animal);
        }
		
        //Dynamic Array
        List<int> numbers = new List<int> {10,20,30};
        numbers.Add(40);
		
        Debug.Log(numbers[2]);
        numbers.Remove(10);
        foreach(int number in numbers)
        {
            Debug.Log(number);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
