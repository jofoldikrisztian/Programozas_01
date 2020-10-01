using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugInfoApp
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property, AllowMultiple = true)]
    public class DebugInfo : Attribute
    {


        private readonly int _bugNo;
        private readonly string _developer;
        private readonly string _lastReview;
        public string message;


        public DebugInfo(int bg, string dev, string d)
        {
            this._bugNo = bg;
            this._developer = dev;
            this._lastReview = d;
        }


        public int BugNo
        {
            get
            {
                return _bugNo;
            }
        }

        public string Developer
        {
            get
            {
                return _developer;
            }
        }

        public string LastReview
        {
            get
            {
                return _lastReview;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

    }
}
