using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    public Material Blank, Breeze, Gold, Monster, Pit, Player, Stench;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public Material ReturnMaterial(string name)
    {
        if (name == "Breeze")
            return Breeze;
        else if (name == "Gold")
            return Gold;
        else if (name == "Monster")
            return Monster;
        else if (name == "Pit")
            return Pit;
        else if (name == "Stench")
            return Stench;
        return Blank;
    }
}
