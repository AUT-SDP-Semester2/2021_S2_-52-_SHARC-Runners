using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterButtons : MonoBehaviour
{
    public MeterScript AbilityMeter; //this allows you to link this script to the meter's script via the inspector
    public int currentAbility; //defines the variable you'd like to keep track of
    public int maxAbility = 8; //defines the maximum value of your variable (keep it at a multiple of 8 so that it matches the meter's sections)


    void Start()
    {
        currentAbility = maxAbility; //sets your variable to maximum from the start
        AbilityMeter.SetMaxAbility(maxAbility); //sets your meter's fill to maximum from the start

    }


    void FixedUpdate()
    {
        AbilityMeter.SetAbility(currentAbility); //links your variable to the meter's fill

    }

    public void Increase()
    {           
            currentAbility += 1; //increases the variable's value by 10
    }

}
