﻿using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public string Name { get; set; }
    public string FavouriteFood { get; set; }

    public virtual string MakeSound()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}