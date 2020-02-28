using System;
namespace rob.API.ApacheISISApi.Representations.layout
{
    public class ObjectLayout
    {
        public LayoutRow[] row { get; set; }
    }

    public class LayoutRow
    {
        public LayoutColumn[] cols { get; set; }
    }
    public class LayoutColumn{}
}
