using Problem.LinkedList;
using Problem.Stack;
using Problem;

ArrayStack<int> arrayStack = new ArrayStack<int>(10);

arrayStack.Push(8790);
arrayStack.Push(1);
arrayStack.Push(424323);
arrayStack.Push(3);
arrayStack.Push(4);
arrayStack.Push(5);
arrayStack.Push(6);


FindSmallestElement findSmallestElement = new FindSmallestElement(arrayStack);
findSmallestElement.ShowStack();

Console.WriteLine($"The biggest element: {findSmallestElement.FindTheBiggestElement()}");
Console.WriteLine($"The smallest element: {findSmallestElement.FindTheSmallestElement()}");