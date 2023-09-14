using UnityEngine;
public class Generics : MonoBehaviour
{
    private void Start()
    {
        int[] intArray = GenericMethod<int>(5, 6);
        Debug.Log(intArray.Length + " " + intArray[0]+ " " + intArray[1]);
        Debug.Log(intArray.GetType());

        string[] strArray = GenericMethod<string>("sad", "ee");
        Debug.Log(strArray[0] + strArray[1]);
        Debug.Log(GenericMethod<string>("sadikshya", "gyawali").GetType());
        
        //2 datatypes at same time as args
        MultiGenerics<int,string>(18,"KD");

        //For MyGenerics class Below
        MyGenerics<int> intGenericClass = new MyGenerics<int>(5, 6);
        Debug.Log(intGenericClass.Add());

        MyGenerics<string> stringGenericClass = new MyGenerics<string>("Hello", " World");
        Debug.Log(stringGenericClass.Add());
    }

    private T[] GenericMethod<T>(T firstElement, T secondElement)
    {
        return new T[] { firstElement, secondElement };
    }

    private void MultiGenerics<T1, T2>(T1 t1, T2 t2)
    {
        Debug.Log(t1.GetType());
        Debug.Log(t2.GetType()); 
    }

}

public class MyGenerics<T>
{
    private T x;
    private T y; 
    
    public MyGenerics(T x, T y)
    {
        this.x = x;
        this.y = y;
    }

    public T Add()
    { 
        dynamic dynamicA = x; 
        dynamic dynamicB = y; 
        dynamic sum = dynamicA + dynamicB;
        return sum;
    }
}

