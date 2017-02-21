using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ezWaiting
{
    public interface ILocalize
    {
        string GetCurrent();
        void SetLocale();
    }
}
