using System.Collections;
using UnityEngine;

public class Actions : MonoBehaviour

{

    // Action declaration
        public System.Action onActionTriggered;

        // Function declaration
        public System.Func<int, int, int> addFunction;

        public void Start()
        {
            StartCoroutine(ActionWithDelay());
        }

        private IEnumerator ActionWithDelay()
        {
            yield return new WaitForSeconds(0.2f);
            // Assign an action to the event
            onActionTriggered += HandleActionTriggered;

            // Assign the function to the delegate
            addFunction = Add;

            // Trigger the action
            onActionTriggered.Invoke();

            // Invoke the function and get the result
            int result = addFunction.Invoke(5, 10);
            Debug.Log("Addition result: " + result);
        }

        private void HandleActionTriggered()
        {
            Debug.Log("Action triggered!");
        }

        private int Add(int a, int b)
        {
            return a + b;
        }
    }



    
    
   