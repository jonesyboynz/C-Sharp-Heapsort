using System;
using System.Collections.Generic;

namespace csharp_heapsort
{
	class MainClass
	{

		public static void DisplayList(List<int> list_to_print){
			//Prints a list to the console
			Console.Write ("List: ");
			for (int i = 0; i < list_to_print.Count; i++) {
				Console.Write ("{0}", list_to_print [i]);
				if (i != list_to_print.Count - 1) {
					Console.Write (",");
				}
			}
			Console.WriteLine("");
		}

		public static void basictest (){
			Heap my_heap = new Heap ();
			Console.WriteLine ("I have created a minheap object!");
			my_heap.Push (51);
			my_heap.Push (121);
			my_heap.Push (30);
			my_heap.Push (12);
			my_heap.Push (21);
			my_heap.Push (48);
			my_heap.Push (91);
			my_heap.Push (37);
			my_heap.Push (32);
			//Console.Write ("Current heap: ");
			Console.WriteLine (my_heap.HeapListString ());
			my_heap.Pop ();
			Console.WriteLine (my_heap.HeapListString ());
			DisplayList (my_heap.Sort());
		}

		public static void Main (string[] args)
		{
			basictest ();
		}
	}
}