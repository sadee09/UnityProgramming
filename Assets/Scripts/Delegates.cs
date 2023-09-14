using UnityEngine;

public class Delegates : MonoBehaviour
{
    public class Calculator
    {
        public delegate int OperationDelegate(int a, int b);

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public void PerformOperation(int a, int b, OperationDelegate operationDelegate)
        {
            int result = operationDelegate(a, b);
            Debug.Log("Result: " + result);
        }
    }

    private void Start()
    {
        Calculator calculator = new Calculator();
        Calculator.OperationDelegate addDelegate = calculator.Add;
        Calculator.OperationDelegate subtractDelegate = calculator.Subtract;

        calculator.PerformOperation(5, 3, addDelegate);
        calculator.PerformOperation(10, 4, subtractDelegate);
    }
}
      // class Delegate
      // {
      //       delegate void DelegateExample(int a);
      //
      //       void Start()
      //       {
      //             DelegateExample delegateExample = Bar;
      //             delegateExample(4);
      //       }
      //
      //       void Bar(int a)
      //       {
      //
      //       }
      //
      //       void Foo(int a)
      //       {
      //
      //       }
      // }
public class PlayerStats
{
    public string name;
    public int kills;
    public int deaths;
    public int flagsCaptured;
}


public class Delegate
{
    delegate int ScoreDelegate(PlayerStats stats);

    void OnGameOver(PlayerStats[] allPlayerStats)
    {
        string mostkills = TopScore(allPlayerStats, ScorebyKill);
        string mostflags = TopScore(allPlayerStats, ScorebyFlag);
    }

    int ScorebyKill(PlayerStats stats)
    {
        return stats.kills;
    }

    int ScorebyFlag(PlayerStats stats)
    {
        return stats.flagsCaptured;
    }

    string TopScore(PlayerStats[] allPlayerStats, ScoreDelegate scoreCalculator)
    {
        string name = "";
        int bestScore = 0;
        foreach (PlayerStats stats in allPlayerStats)
        {
            int score = scoreCalculator(stats);
            if (score > bestScore)
            {
                bestScore = score;
                name = stats.name;
            }
        }

        return name;
    }
}