using System;
using System.Collections.Generic;
using System.Text;

class AddCollection : AbstactList, IAddLast
{
    public AddCollection(List<string> input) : base(input) { }

    public string AddLastElement()
    {
        throw new NotImplementedException();
    }
}