using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace SignInApp
{
    [DataContract]
    class Team
    {
        [DataMember]
        public int Number;

        [DataMember]
        public string Name;

        [DataMember]
        public List<Member> Members;

        public string Serialize()
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(Team));
                serializer.WriteObject(ms, this);
                byte[] json = ms.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }

        public void Deserialize(string json)
        {
            var deserializedTeam = new Team();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(deserializedTeam.GetType());
                deserializedTeam = serializer.ReadObject(ms) as Team;
                ms.Close();
            }
            Name = deserializedTeam.Name;
            Number = deserializedTeam.Number;
            Members = deserializedTeam.Members;
        }

        public void AddMember(int number, string firstName, string lastName)
        {
            if (Members == null)
                Members = new List<Member>();

            Members.Add(new Member(number, firstName, lastName));
        }

        public Team(string name, int number, Member[] members)
        {
            Name = name;
            Number = number;
            Members = new List<Member>(members);
        }

        public Team(string name, int number)
        {
            Name = name;
            Number = number;
            Members = new List<Member>();
        }

        public Team()
        {
            Name = "";
            Number = 0;
            Members = new List<Member>();
        }

    }

    [DataContract]
    public class Member
    {
        [DataMember]
        public int Number;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        public Member(int number, string firstName, string lastName) {
            Number = number;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    [DataContract]
    public class SignInEvent
    {
        [DataMember]
        public int Number;

        [DataMember]
        public int SignInYear;

        [DataMember]
        public int SignInMonth;

        [DataMember]
        public int SignInDate;

        [DataMember]
        public int SignInHour; //0 - 23

        [DataMember]
        public int SignInMinute;

        [DataMember]
        public int SignInSecond;

        [DataMember]
        public int SignOutYear;

        [DataMember]
        public int SignOutMonth;

        [DataMember]
        public int SignOutDate;

        [DataMember]
        public int SignOutHour; //0 - 23

        [DataMember]
        public int SignOutMinute;

        [DataMember]
        public int SignOutSecond;

        public DateTime TimeIn;

        public DateTime TimeOut;

        public TimeSpan TimeElapsed {
            get {
                try
                {
                    DateTime signIn = new DateTime(SignInYear, SignInMonth, SignInDate, SignInHour, SignInMinute, SignInSecond);

                    DateTime signOut = new DateTime(SignOutYear, SignOutMonth, SignOutDate, SignOutHour, SignOutMinute, SignOutSecond);

                    return signOut.Subtract(signIn);
                }
                catch (Exception e)
                {
                    return new TimeSpan();
                }
            }
        }

        public void SetTimeIn(DateTime time)
        {
            TimeIn = time;

            SignInYear = time.Year;
            SignInMonth = time.Month;
            SignInDate = time.Day;
            SignInHour = time.Hour;
            SignInMinute = time.Minute;
            SignInSecond = time.Second;
        }

        public void SetTimeOut(DateTime time)
        {
            TimeOut = time;

            SignOutYear = time.Year;
            SignOutMonth = time.Month;
            SignOutDate = time.Day;
            SignOutHour = time.Hour;
            SignOutMinute = time.Minute;
            SignOutSecond = time.Second;
        }

        public void TrackTime(DateTime time)
        {
            if (TimeIn == null)
            {
                SetTimeIn(time);
            } else
            {
                SetTimeOut(time);
            }
        }

        public SignInEvent(int number, DateTime time)
        {
            Number = number;
            SetTimeIn(time);
        }
    }

    [DataContract]
    public class SignInEventList
    {
        [DataMember]
        public List<SignInEvent> EventList;

        public string Serialize()
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(SignInEventList));
                serializer.WriteObject(ms, this);
                byte[] json = ms.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }

        public void Deserialize(string json)
        {
            var deserializedEventList = new SignInEventList();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(deserializedEventList.GetType());
                deserializedEventList = serializer.ReadObject(ms) as SignInEventList;
                ms.Close();
            }
            EventList = deserializedEventList.EventList;
        }

        public SignInEventList GetEventsByDate(DateTime date)
        {
            SignInEventList ret = new SignInEventList();

            foreach (SignInEvent inEvent in EventList) 
            {
                if (inEvent.SignInYear == date.Year && inEvent.SignInMonth == date.Month && inEvent.SignInDate == date.Day)
                    ret.AddMember(inEvent);
            }

            return ret;
        }

        public SignInEventList GetEventsByNumber(int number)
        {
            SignInEventList ret = new SignInEventList();

            foreach (SignInEvent inEvent in EventList)
            {
                if (inEvent.Number == number)
                    ret.AddMember(inEvent);
            }

            return ret;
        }

        public void AddMember(SignInEvent inEvent)
        {
            EventList.Add(inEvent);
        }

        public void TrackNumber(int number)
        {
            foreach (SignInEvent inEvent in EventList)
            {
                if (inEvent.Number == number)
                {
                    inEvent.TrackTime(DateTime.Now);
                    return;
                }
            }
            AddMember(new SignInEvent(number, DateTime.Now));
        }

        /**
         *  Returns true if tracked data is unloaded, returns false otherwise 
         */
        public bool TrackAndUnloadNumber(int number, ref SignInEventList unloadList)
        {
            foreach (SignInEvent inEvent in EventList)
            {
                if (inEvent.Number == number)
                {
                    inEvent.TrackTime(DateTime.Now);
                    unloadList.AddMember(inEvent);
                    EventList.Remove(inEvent);
                    return true;
                }
            }
            EventList.Add(new SignInEvent(number, DateTime.Now));
            return false;
        }

        public TimeSpan SumTime()
        {
            TimeSpan totalTime = new TimeSpan(00, 00, 00, 00, 00);

            foreach (SignInEvent inEvent in EventList)
            {
                totalTime = totalTime.Add(inEvent.TimeElapsed);
            }

            return totalTime;

        }

        public SignInEventList()
        {
            EventList = new List<SignInEvent>();
        }
    }
}
