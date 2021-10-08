using System;

public class Class1
{
	public Class1()
	{public class User
    {
        public Guid ID { get; set; } = Guid.NewGuid();
       
        public string Fullname { get; set; }
        public string FullName
        {
            get
            {
                return string.Format(
                    "{0} {1}",
                    LastName,
                    FirstName);
            }
        }

       
    }
}

