using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CA.Task1{
	
	class ProcessingApplication{
		public void delay(){
			Console.Write("Task completed. Returning to menu.");
			Console.Write(".");
			System.Threading.Thread.Sleep(600);
			Console.Write(".");
			System.Threading.Thread.Sleep(600);
			Console.Write(".");
			System.Threading.Thread.Sleep(600);
		}
		
		public void sentenceReverser(){
			string input1;
			Console.WriteLine("Enter the sentence you would like to reverse: ");
			try {
				input1 = Console.ReadLine();
				input1 = string.Join(" ", input1.Split(' ').Reverse().ToArray());
				Console.WriteLine("The reversed sentence is: " + input1);
			}
			catch(FormatException){
				Console.WriteLine("That is not a valid input.");
				Console.WriteLine("Enter a string without a period.");
			}
			delay();
			//await Task.Delay(3000);
		}
		
		public void numSwapper(){
			int input2a, input2b;
			T2:
			Console.WriteLine("Enter the two numbers to swap: ");
			try {
				input2a = int.Parse(Console.ReadLine());
				input2b = int.Parse(Console.ReadLine());
				input2a = input2a * input2b;
				input2b = input2a / input2b;
				input2a = input2a / input2b;
				Console.WriteLine("\nThe swapped numbers are: " + input2a + " and " + input2b + ".\n");
			}
			catch(FormatException){
				Console.WriteLine("\nThat is not a valid input.");
				Console.WriteLine("Enter a string without a period.\n");
				goto T2;
			}
			delay();
		}
		
		public void numPatternSearch(){
			string input3;
			//string pattern = @"\b\w+es\b";
			//string pattern = @"\[(.*?)\]";
			string pattern = @"\[(?<numbers>[\d,]+)\]";
			//Regex regex = new Regex("[*]");
			Console.WriteLine("Enter string to search: ");
			input3 = Console.ReadLine();
			//input3 = string.Join("", input3.Where(char.IsDigit).ToArray());
			//input3 = Regex.Match(input3, @"\d+").Value;
			//string[] substrings = regex.Split(input3);
			/*foreach (Match match in Regex.Matches(input3, pattern)){
				int count = 1;
				string[] substrings = "Number"+count+" = '{0}'", match;
				count++;
				Console.WriteLine(substrings);
			}*/
			//Console.WriteLine(input3);
			var numbers = Regex.Match(input3, @"\[(?<numbers>[\d,]+)\]").Groups["numbers"].Value;
			var collectionOfNumbers = numbers.Split(',');
			var strings = numbers.Split(',').Select((number, i) => string.Format("Number{0} = {1}", i+1, number));
			Console.WriteLine(string.Join("\n", strings));
			/* List<string> substrings = new List<string>();
			int count = 1;
			foreach (Match match in Regex.Matches(input3, pattern)){
				string substring = string.Format("Number{0} = '{1}'",count,match);
				count++;
				Console.WriteLine(substring);
				substrings.Add(substring);
			}
			string[] subStringArray = substrings.ToArray(); */
			
			delay();
		}
	}
	
	class MenuApplication{
		
		static void Main(string[] args){
			ProcessingApplication pa = new ProcessingApplication();
			int choice;
			//bool control = true;
			Console.WriteLine("\nHey Code Authority! Here's the first Task.");
			Loop:
			Console.WriteLine("\n******************* MENU *********************");
			Console.WriteLine("* 1. Sentence Reverser                       *");
			Console.WriteLine("* 2. Number Swap                             *");
			Console.WriteLine("* 3. Number Pattern Searcher                 *");
			Console.WriteLine("* 4. Exit                                    *");
			Console.WriteLine("**********************************************");
			Console.WriteLine("Enter your choice: ");
			try {
				choice = int.Parse(Console.ReadLine());
				switch(choice){
					case 1:
						//Console.WriteLine("a");
						pa.sentenceReverser();
						goto Loop;
				
					case 2:
						//Console.WriteLine("b");
						pa.numSwapper();
						goto Loop;
					
					case 3:
						//Console.WriteLine("c");
						pa.numPatternSearch();
						goto Loop;
					
					case 4:
						break;
						//control = false;
				}
			}
			catch(FormatException){
				Console.WriteLine("\nThat is not a valid input.");
				Console.WriteLine("Enter a number between 1 and 4.\n");
				goto Loop;
				//continue;
			}
		}
	}
}
