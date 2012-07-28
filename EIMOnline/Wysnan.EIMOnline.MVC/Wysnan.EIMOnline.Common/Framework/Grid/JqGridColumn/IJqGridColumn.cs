using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;

namespace Wysnan.EIMOnline.Common.Framework.Grid.Interfaces
{
    public interface IJqGridColumn
    {
        string Label { get; set; }

        GridColumnAlign Align { get; set; }

        string Name { get; }

        string Type { get; }

        bool Hidden { get; set; }
    }
}
