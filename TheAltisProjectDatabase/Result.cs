using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheAltisProjectDatabase
{
    public class Result
    {
        private int _CurrentIndex;
        private string[] _Results;

        public Result(string[] results)
        {
            _Results = results;
            _CurrentIndex = 0;
        }

        public string Next()
        {
            if (_Results == null)
                return null;
            if (_CurrentIndex >= _Results.Length)
                return null;

            _CurrentIndex++;
            return _Results[_CurrentIndex - 1];
        }
    }
}
