using System;
using System.Collections.Generic;
using System.Text;

class AddRemoveCollection : AbstactList, IAddFirst, IRemoveLast
{
    public AddRemoveCollection(List<string> input) : base(input) { }

    public string AddFirstElement()
    {
        throw new NotImplementedException();
    }

    public string RemoveLastElement()
    {
        throw new NotImplementedException();
    }
}