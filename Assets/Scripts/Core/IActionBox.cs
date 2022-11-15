using System;


namespace Diaco.Manhatan
{
    public interface IActionBox
    {
        bool Inside
        {
            set;
            get;
        }

        
        void InActionBox();
        void OutActionBox();
      
    }
}
