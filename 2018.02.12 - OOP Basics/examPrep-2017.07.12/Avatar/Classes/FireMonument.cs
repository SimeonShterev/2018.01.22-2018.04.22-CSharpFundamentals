﻿using System;
using System.Collections.Generic;
using System.Text;

public class FireMonument : Monument
{
	public FireMonument(string name, int fireAffinity)
		: base(name)
	{
		this.FireAffinity = fireAffinity;
	}

	public int FireAffinity { get; set; }
}