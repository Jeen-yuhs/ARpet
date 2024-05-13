using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy;
    public int foodTickRate, happinessTickRate, energyTickRate;
    public DateTime lastTimeFed, lastTimeHappy, lastTimeEnergized;
   
    private void Awake()
    {
        Initialize(100, 100, 100, 5, 2, 1);
    }

    public void Initialize(int food, int happiness, int energy, int foodTickRate, int happinessTickRate, int energyTickRate)
    {
        lastTimeFed = DateTime.Now;
        lastTimeHappy = DateTime.Now;
        lastTimeEnergized = DateTime.Now;
        
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;       
        
    }

    public void Initialize(int food, int happiness, int energy, int foodTickRate, int happinessTickRate, int energyTickRate, DateTime lastTimeFed, DateTime lastTimeHappy, DateTime lastTimeEnergized) 
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeEnergized = lastTimeEnergized;
        
        this.food = food - foodTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeFed, TimingManager.instance.hourLength);
        this.happiness = happiness - happinessTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeHappy, TimingManager.instance.hourLength);
        this.energy = energy - energyTickRate * TickAmountSinceLastTimeToCurrentTime(lastTimeEnergized, TimingManager.instance.hourLength);
        
        this.foodTickRate = foodTickRate; 
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        
        if (this.food < 0) this.food = 0;
        if (this.happiness < 0) this.happiness = 0;
        if (this.energy < 0) this.energy = 0;       
        
    }

    private void Update()
    {
        if(TimingManager.instance.gameHourTimer < 0) 
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);            
        }
        PetUIController.instance.UpdateImages(food, happiness, energy);
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        if(amount  > 0) 
        {
            lastTimeFed = DateTime.Now;
        } 
        if (food < 0)
        {
            PetManager.instance.Die();
        }
        else if (food > 100) food = 100;
    }
    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if (amount > 0)
        {
            lastTimeHappy = DateTime.Now;
        }
        if (happiness < 0)
        {
            PetManager.instance.Die();
        }
        else if (happiness > 100) happiness = 100;
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if (amount > 0)
        {
            lastTimeEnergized = DateTime.Now;
        }
        if (energy < 0)
        {
            PetManager.instance.Die();
        }
        else if (energy > 100) energy = 100;
    }

    public int TickAmountSinceLastTimeToCurrentTime(DateTime lastTime, float tickRateInSeconds) 
    { 
        DateTime currentDateTime = DateTime.Now;
        int dayOfYearDifference = currentDateTime.DayOfYear - lastTime.DayOfYear;
        if (currentDateTime.Year > lastTime.Year || dayOfYearDifference >= 7) return 1500;

        int dayDifferenceSecondsAmount = dayOfYearDifference * 86400;        
        if (dayOfYearDifference > 0) return Mathf.RoundToInt(dayDifferenceSecondsAmount/tickRateInSeconds);

        int hourDifferenceSecondsAmount = (currentDateTime.Hour - lastTime.Hour) * 3600;
        if (hourDifferenceSecondsAmount > 0) return Mathf.RoundToInt(hourDifferenceSecondsAmount / tickRateInSeconds);

        int minuteDifferenceSecondsAmount = (currentDateTime.Minute - lastTime.Hour) * 60;
        if (minuteDifferenceSecondsAmount > 0) return Mathf.RoundToInt(minuteDifferenceSecondsAmount / tickRateInSeconds);

        int secondDifferenceAmount = (currentDateTime.Second - lastTime.Second);
        return Mathf.RoundToInt(secondDifferenceAmount/tickRateInSeconds);
    }
}


