using System;
using System.Collections.Generic;
using System.Text;

public interface IAddRemove : IAdd
{
    void Remove(int count);
}