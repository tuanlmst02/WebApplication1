using CommunityToolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	class Employee
	{
        public int CountCharsUsingLinqCount(string source, char toFind)
        {
			int count = 0;
			foreach (var item in source)
			{
				if (item == toFind)
					count++;
			}
			return count;
        }
    }
}
