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

		public static void BasicTests (){
			//Implements some basic tests for the heap
			Heap my_heap = new Heap ();
			Console.WriteLine ("I have created a minheap object!\nAdding data to it now.");
			my_heap.Push (51);
			my_heap.Push (121);
			my_heap.Push (30);
			my_heap.Push (12);
			my_heap.Push (21);
			my_heap.Push (48);
			my_heap.Push (91);
			my_heap.Push (37);
			my_heap.Push (32);
			Console.WriteLine ("The heap currently has {0} nodes.", my_heap.Length ());
			//Console.Write ("Current heap: ");
			Console.WriteLine (my_heap.HeapListString ());
			Console.WriteLine ("Popping a node.");
			my_heap.Pop ();
			Console.WriteLine ("The heap currently has {0} nodes.", my_heap.Length ());
			Console.WriteLine (my_heap.HeapListString ());
			Console.WriteLine ("Sorting the heap.");
			DisplayList (my_heap.Sort());
			Console.WriteLine (my_heap.HeapListString ());
			Console.WriteLine ("The heap currently has {0} nodes.", my_heap.Length ());
			Console.WriteLine ("Heap property is satisfied: {0}", my_heap.IsHeap (1));
		}

		public static void Main (string[] args)
		{
			BasicTests ();
			for (int i = 0; i < 10; i++) {
				RandomArraySortTest ();
			}
		}

		public static void RandomArraySortTest(){
			//Tests that the heapsort can correctly sort an array of random numbers
			Random rng = new Random ();
			List<int> random_list = new List<int> ();
			List<int> sorted_heap;
			int failures = 0;
			Heap my_heap = new Heap ();
			int elements = rng.Next (100, 10000); //number of elements in the random array
			for (int i = 0; i < elements; i++) { //create random number and add them to an array and the heap
				int current_element = rng.Next ();
				random_list.Add (current_element);
				my_heap.Push (current_element);
			}
			Console.WriteLine ("Pushed {0} elements into heap. Heap valid: {1}", elements, my_heap.IsHeap ());
			sorted_heap = my_heap.Sort ();
			random_list.Sort ();
			for (int j = 0; j < elements; j++) {
				if (random_list [j] != sorted_heap [j]) {
					Console.WriteLine ("Sort failed at {0}: Heap: {1}, C#Sort: {2}", j, sorted_heap [j], random_list [j]);
					failures += 1;
				}
			}
			Console.WriteLine("Sorted {0} random numbers with {1} errors.", elements, failures);
		}
	}
}