using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class Singleton
    {
        private static Backend.Singleton _mInstance;

        public static Backend.Singleton Instance
        {
            get { return _mInstance ?? (_mInstance = new Backend.Singleton()); }
        }

        private string _cbbadress;

        /// <summary>
        /// cbbAdress.
        /// </summary>
        public string cbbadress
        {
            get { return _cbbadress; }
            set { _cbbadress = value; }
        }
    }

}
