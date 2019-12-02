using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateScript : MonoBehaviour
{
    // Click me...
    #region
    // Delegates can be thought of as a messaging service. The delegate is responsible for delivering
    // messages to all subscribed functions. When the message is sent, subscribed functions respond
    // by activating their subscribed functions. Any number of functions can subscribe to a single delegate
    // and they're super useful for coordinating logic across many scripts. Using Delegate helps
    // prevent spaghetti code where hard coded references are used - that becomes confusing and easily breakable.
    // The delegate helps de-couple your code whilst creating an ordered and reliable way to control complex logical tasks.
    #endregion
    
    
    // Here we define a delegate, it's return type and any required function paramters.
    // In this case, my delegate doesn't return anything (void) and takes no parameters.
    
    public delegate void MyNewDelegate();
    
    // Next we create a new instance of the delegate and give it a name.
    // We make it static so we can access it from other scripts across our project.

    public static MyNewDelegate TestDelegate;
    
    
    // Update is called once per frame
    void Update()
    {
        
        // In this simple example, player input is tested, but this could be triggered by
        // any game logic event.
        // We also check to see if out Delegate has some subscribers by testing it against
        // nothing (null). Firing a delegate event with no subscribers will trigger an error
        // messsage.
        
        if (Input.GetKeyDown(KeyCode.I) && TestDelegate != null)
        {
            TestDelegate();
        }
    }
}
