using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    // For updating text
    public Text animal;
    public Text day;
    public Text spaces;

    // Animals start with 7 energy, 0 Experience
    int energy = 7;
    int experience = 0;
    int swol = 1;
    int moveCounter = 0;
    int spacesMoved = 0;
    int currDay = 1;
    string currAnimal;

    // Initialize variables
    void Start()
    {
        currAnimal = animal.text;
        animal.text = currAnimal + "Swol: " + swol + " Energy: " + energy + " Exp: " + experience;
    }

    // Button Function
    public void Feed() 
    {
        energy += 5;
        UpdateText();
    }

    void UpdateText()
    {
        animal.text = currAnimal + "Swol: " + swol + " Energy: " + energy + " Exp: " + experience;
        spaces.text = "Spaces Moved: " + spacesMoved;
    }
     // Energy -> Exp -> Noah

// When Energy goes to 0, Can't get Swol
// Noah gets 12 moves a day and must return to his home at the end of the day
// Noah can come feed animals, Energy increase by 5 when on same space as animal
// Animals lose 1 energy every 2 moves
//                 gain 1 exp if they have energy
//                 gain 1 swol for every 3 experience
// If animals goes to sleep w/o energy, -1 swol

    // button functions to update when move button is pressed
    public void Move() 
    {
        spacesMoved++;
        if(moveCounter != 1)
            moveCounter++;
        else
            moveCounter = 0;

        // Gain exp if animal has energy every 2 moves
        if(energy > 0 && moveCounter == 1) 
        {
            energy--;
            
            if(experience < 3) 
                experience++;
            if(experience == 3)
            {
                experience = 0;
                swol++;
            }
        } 
        // might need to change this so it doesnt run 4 times
        if(spacesMoved == 12) {
            EndDay();
            spacesMoved = 0;
        }
        UpdateText();
    }

    public void EndDay()
    {
        // lose swol if animal has no energy
        if(energy == 0 && swol > 1)
            swol--;
        
        // update current day
        currDay++;
        day.text = "Day: " + currDay;
        spaces.text = "Spaces Moved: " + spacesMoved;
    }

}
