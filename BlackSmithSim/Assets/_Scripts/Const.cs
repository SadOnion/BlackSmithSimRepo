using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const  {

    public static Color bronzeColor = new Color(224, 110, 58,255);
    
    public static Color ironColor = new Color(118, 98, 90, 255);
    public static Color titanumColor = new Color(255, 255, 255, 255);
    public static Color cobaltColor = new Color(59, 64, 204, 255);
    public static Color mythrilColor = new Color(95, 176, 132, 255);


    public static Color GetColorFor(Metal m)
    {
        switch (m)
        {
            case Metal.Bronze:
                return bronzeColor;
                
            case Metal.Iron:
                return ironColor;
            case Metal.Titanum:
                return titanumColor;
            case Metal.Cobalt:
                return cobaltColor;
            case Metal.Mythril:
                return mythrilColor;
            default:
                return cobaltColor;
        }
    }
}
