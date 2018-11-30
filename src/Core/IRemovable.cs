using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core
{
    public interface IRemovable
    {
        event EventHandler Removed;

        void PrepareForRemoval();
    }
}
