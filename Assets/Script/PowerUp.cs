using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp
{
    private static PowerUp instance = null;

    public static PowerUp Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new PowerUp();
            }
            return instance;
        }
        private set
        {

        }
    }
    public int might { get; private set; }
    
    


}