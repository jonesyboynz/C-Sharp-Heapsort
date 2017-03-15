//Implementation of a binary minheap
//By Simon Jones
//14/3/2017

using System;
using System.Collections.Generic;


namespace csharp_heapsort
	

{
	class Heap{ //A binary minheap
		private List<int> heap_array;
		private int count;

		public Heap(){
			//Constructs a minheap
			count = 0;
			heap_array = new List<int>();
			heap_array.Add (0); //The first element in the minheap array is not used. This makes the first element in the heap start at index 1 which simplifies parent/child node index calculations
		}

		public int Peek(){
			//Returns the first element in the minheap.
			if (Length() > 0) {
				return heap_array[1];
			} else {
				throw new System.ArgumentException ("Cannot pop/peek an empty heap");
			}
		}

		public int Length(){
			//returns the number of elements in the minheap. This is also the index of the last item in the heap
			return count;
		}

		public void Push(int value){
			//Inserts a value into the minheap
			count += 1;
			heap_array.Add (value);
			Heapify (Length());
		}

		private void Heapify(int index){
			//Re-establishes the heap property
			int parent_index = index / 2;
			if (index > 1) { //End epify once the root node is reached
				if (heap_array [index] < heap_array [parent_index]) {
					Swap (index, parent_index); //swap the parent and child nodes
					Heapify (parent_index);
				}
			}
		}

		public int Pop(){
			//Returns the root node of the heap
			int return_value = Peek();
			heap_array [1] = heap_array [Length()];
			heap_array.Remove (Length());
			count -= 1;
			ReOrderNode(1);
			return return_value;
		}

		private void ReOrderNode(int index){
			//Swaps the node with its children to ensure that the heap property is satisfied
			int left_child_index = index * 2;
			int right_child_index = index * 2 + 1;
			if (left_child_index > Length()) { //No children remain
				return;
			} else if (right_child_index > Length() && left_child_index == Length()) { //Only one child
				if (heap_array [left_child_index] < heap_array [index]) {
					Swap (index, left_child_index);
					//In this case the left child is a leaf node so re_order_node need not be called
				}
			} else { //Two children
				if (heap_array [left_child_index] < heap_array [index] || heap_array [right_child_index] < heap_array [index]) {
					if (heap_array [right_child_index] < heap_array [left_child_index]) { //Choose the minimum child (this also works if only one child is less than the parent)
						Swap (index, right_child_index);
						ReOrderNode (right_child_index);
					} else {
						Swap (index, left_child_index);
						ReOrderNode (left_child_index);
					}
				}
			}
		}

		private void Swap(int index_a, int index_b){
			//Swaps two nodes in the heap
			int temp;
			if (index_a > Length() || index_b > Length()){
				throw new System.ArgumentException ("Cannot swap elements beyond the length of the heap array!");
			}
			else{
				temp = heap_array [index_a];
				heap_array [index_a] = heap_array [index_b];
				heap_array [index_b] = temp;
			}
		}

		public string HeapListString(){
			//Returns the heap array as a string. Useful for debugging
			string heap_data_string = "Heap data: ";
			for (int i = 1; i < Length() + 1; i++){
				string item_string = String.Format("{0},", heap_array[i]);
				heap_data_string += item_string;
			}
			return heap_data_string;
		}

		public List<int> Sort(){
			//Returns a sorted array of the heap (smalled-to-largest)
			List<int> heap_copy = new List<int>(heap_array);
			List<int> sorted_heap = new List<int>();
			int length = Length ();
			while (Length() > 0) {
				sorted_heap.Add (Pop ());
			}
			heap_array = new List<int> (heap_copy);
			count = length;
			return sorted_heap;
		}

		public List<int> GetHeapList(){
			//Returns a copy of the heap array
			return new List<int> (heap_array);
		}

		public bool IsHeap(int index){
			//Indicates if a sub-tree saisfies the heap property
			int left_child_index = index * 2;
			int right_child_index = index * 2 + 1;
			if (left_child_index > Length () && right_child_index > Length ()) {
				return true;
			} else if (right_child_index > Length () && left_child_index == Length ()) {
				return (heap_array [index] <= heap_array [left_child_index]);
			} else {
				bool left_is_heap = IsHeap (left_child_index) && (heap_array[index] <= heap_array[left_child_index]);
				bool right_is_heap = IsHeap (right_child_index) && (heap_array[index] <= heap_array[right_child_index]);
				return left_is_heap && right_is_heap;
			}
		}

		public bool IsHeap(){
			//Overloaded IsHeap. Runs IsHeap on the root node.
			return IsHeap (1);
		}

	}

}

