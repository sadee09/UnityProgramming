using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSecond : MonoBehaviour
{
    public delegate void SpaceBarClicked();
        public event SpaceBarClicked OnSpaceBar;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(OnSpaceBar != null) 
                    OnSpaceBar.Invoke();
            }
        }
    
}
