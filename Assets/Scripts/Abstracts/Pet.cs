using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pet
{
    public string lastTimeFed, lastTimeHappy, lastTimeEnergized;
    public int food, happyness, energy;

    public Pet(string lastTimeFed, string lastTimeHappy, string lastTimeEnergized, int food, int happyness, int energy)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeEnergized = lastTimeEnergized;
        this.food = food;
        this.happyness = happyness;
        this.energy = energy;
    }
       
}
