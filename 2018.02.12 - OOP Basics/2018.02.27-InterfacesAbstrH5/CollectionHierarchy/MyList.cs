using System;
using System.Collections.Generic;
using System.Text;

class MyList : AbstactList, IAddFirst, IRemoveLast
{
    public MyList(List<string> input) : base(input) { }

    public string AddFirstElement()
    {
        throw new NotImplementedException();
    }

    public string RemoveLastElement()
    {
        throw new NotImplementedException();
    }
}