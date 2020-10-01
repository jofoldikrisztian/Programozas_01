using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserApp
{
    class Statistics
    {
        private readonly List<User> _users;

        public Statistics(List<User> users)
        {
            _users = users;
        }
        private DateTime getLowestDate()
        {
            DateTime dateTime = DateTime.MinValue;
            foreach (var user in _users)
            {
                if (user.dateOfBirth > dateTime)
                {
                    dateTime = user.dateOfBirth;
                }
            }
            return dateTime;
        }

        public User getYoungest()
        {
            DateTime lowestDateTime = getLowestDate();
            foreach (var user in _users)
            {
                if (user.dateOfBirth == lowestDateTime)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
