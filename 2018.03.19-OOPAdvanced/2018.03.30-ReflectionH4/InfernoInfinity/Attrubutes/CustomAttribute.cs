﻿using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CustomAttribute : Attribute
{
	public CustomAttribute(string author, int revision, string description, string[] reviewers)
	{
		this.Author = author;
		this.Revision = revision;
		this.Description = description;
		this.Reviewers = reviewers;
	}

	public string Author { get; private set; }

	public int Revision { get; private set; }

	public string Description { get; private set; }

	public string[] Reviewers { get; private set; }
}