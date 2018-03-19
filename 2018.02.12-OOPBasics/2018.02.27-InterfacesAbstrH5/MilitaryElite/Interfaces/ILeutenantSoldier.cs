using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantSoldier
{
    IReadOnlyCollection<ISolder> PrivatesSet { get; }

    void AddPrivate(ISolder @private);
}