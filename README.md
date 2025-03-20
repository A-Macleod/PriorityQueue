
<div align="center">
<img src="https://github.com/user-attachments/assets/3f546352-b5c7-4f97-af06-1d2d7bb7b02a"/>
</div>
<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-Orange"/>
  <img src="https://img.shields.io/badge/Last%20Commit-March%202025-Orange">
</p>

# *Software Construction UG409765*

## Priority Queue Class Library - Assessment 1

### Description
This repository is **Assessment 1** of the module **UG409765 - Software Construction** of the **BSc Computing** program at the **University of the Highlands and Islands (UHI)**. It serves as the foundation for the Priority Queue class library, written in C#. The implementations of priority queue consist of four different types of data structure along with Nunit tests for each queue implementation and a driver program implemented as a Windows Form Application to allow users to interact with the different queue types: 

* Unsorted Array Priority Queue
* Unsorted Linked List Priority Queue
* Sorted Array Priority Queue
* Sorted Linked List Priority Queue

<br>
<br>
<div align="center">
<img src="https://github.com/user-attachments/assets/9dad2c5d-ad1d-47b4-9cc4-e123d0dcc5c6"/>
</div>


---

### Table of Contents
1. [Description](#description)
2. [Repository Structure](#repository-structure)
3. [Installation](#installation)
4. [Collaboration](#collaboration)
5. [License](#license)
6. [Contact](#contact)

---

# Repository Structure
The solution consists of two projects, PriorityQueue and PriorityQueue.Tests

---

`Project` `PriorityQueue`
- `Node.cs`: A class used to represent an element in the Linked List Priority Queue data structures. It contains the Item (Person), Priority and Next pointer to the node. 
- `Person.cs`: A class used as a type for testing priority queues with the provided driver program.
- `PriorityItem.cs`: A class representing individual items within the priority queue. It includes properties for the item and its priority.
- `PriorityQueue.cs`: An interface defining the required methods for all Priority Queue implementations. This interface must not be modified.
- `QueueManager.cs`: A driver program implemented as a Windows Form application. It allows users to interact with and test different Priority Queue implementations.
- `QueueOverflowException.cs`:  A custom exception class for handling scenarios where the queue exceeds its defined capacity.
- `QueueUnderflowException.cs`: A custom exception class for handling scenarios where an operation is attempted on an empty queue.
- `SortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using a sorted array. Highest priority is always at the head of the queue.
- `SortedLinkedPriorityQueue.cs`: A complete implementation of the Priority Queue using a linked list that is sorted according to priority. Highest priority is always at the head of the queue. 
- `UnsortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using an unsorted array. 
- `UnsortedLinkedPriorityQueue.cs`: A complete implementation of the Priority Queue using a linked list that is unsorted.  

`Project` `PriorityQueue.Tests`
- `QueueManager.Tests.cs`: Nunit testing for the QueueManager user interface.
- `SortedArrayPriorityQueue.Tests.cs`: Nunit testing for the sorted array priority queue implementation.
- `SortedLinkedPriorityQueue.Tests.cs`: Nunit testing for the sorted linked list priority queue implementation.
- `UnsortedArrayPriorityQueue.Tests.cs`: Nunit testing for the unsorted array priority queue implementation.
- `UnsortedLinkedPriorityQueue.Tests.cs`: Nunit testing for the unsorted linked list priority queue implementation.

---

# Installation
Following the steps below should install all dependencies referenced inside the PriorityQueue.csproj file for the entire project including Nunit and its dependencies for testing.

---

1. Check If Git is installed
```bash
git --version
```

2. Check if .NET is installed
```bash
dotnet --version
```

3. Navigate to Project directory
```bash
cd path\to\project
```

4. Clone Repo
```bash
gh repo clone A-Macleod/PriorityQueue
```

5. Install Dependencies 
```bash
dotnet restore
```

6. Build Project
```bash
dotnet build
```

7. Run Project
```bash
dotnet run
```

---

# Collaboration 
I am currently not looking for collaborators on this project

# License
UHI

# Contact
For any issues or questions, please reach out to 0308180@uhi.ac.uk
