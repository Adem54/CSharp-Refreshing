using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    [Serializable]
    public class CustomException:Exception
    {
        public int StatusCode { get;}

        protected CustomException(
            SerializationInfo info, 
            StreamingContext context ):base(info, context)
        { }
        public CustomException()
        {
            
        }
        public CustomException(string message, int statusCode, Exception innerException):base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public CustomException(string message, int statusCode):base(message)
        {
            StatusCode = statusCode;            
        }

        public CustomException(string message, Exception innerException):base(message, innerException) 
        {
            
        }
    }

    public class Person
    {
        public Person(string name, int  yearOfBirth)
        {
            
            if(yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException("The year of birth must be " +
                    " between 1900 and the current year");
            }
        }
    }
}
