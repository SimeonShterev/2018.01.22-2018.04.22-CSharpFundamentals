using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Person
    {
		private long id;
		private string userName;

		public Person(long id, string userName)
		{
			this.id = id;
			this.userName = userName;
		}

		public long Id => this.id;

		public string UserName => this.userName;
    }
}
