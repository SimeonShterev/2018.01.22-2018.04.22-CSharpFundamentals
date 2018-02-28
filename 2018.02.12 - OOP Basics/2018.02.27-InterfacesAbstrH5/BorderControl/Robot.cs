﻿using System;
using System.Collections.Generic;
using System.Text;

public class Robot :IResidents
{
    public Robot(string id, string name)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; set; }
    public string Id { get; set; }
}