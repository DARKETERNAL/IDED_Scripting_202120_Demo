using System;
using System.Collections.Generic;

public class DataStructTester
{
    private int[] intArray = new int[10];
    private List<int> intList = new List<int>(); // Don't know size

    public int[] IntArray { get => intArray; private set => intArray = value; }
    public List<int> IntList { get => intList; private set => intList = value; }

    public void FillCollections()
    {
        Random random = new Random();

        for (int i = 0; i < IntArray.Length; i++)
        {
            IntArray[i] = random.Next(1, 20);

            IntList.Add(random.Next(1, 20));
        }
    }

    public bool IsPalindrome(string source, int method = 0)
    {
        bool result = true;

        switch (method)
        {
            case 1: // Stack
                Stack<char> stackA = new Stack<char>();
                Stack<char> stackB = new Stack<char>();

                // Filling stacks.
                for (int i = 0; i < source.Length; i++)
                {
                    stackA.Push(source[i]);
                    stackB.Push(source[source.Length - 1 - i]);
                }

                if (stackA.Count == stackB.Count)
                {
                    while (stackA.Count > 0 && result)
                    {
                        result = stackA.Pop() == stackB.Pop();
                    }
                }
                else
                {
                    result = false;
                }
                break;

            case 2: // Queue
                Queue<char> queueA = new Queue<char>();
                Queue<char> queueB = new Queue<char>();

                // Filling stacks.
                for (int i = 0; i < source.Length; i++)
                {
                    queueA.Enqueue(source[i]);
                    queueB.Enqueue(source[source.Length - 1 - i]);
                }

                if (queueA.Count == queueB.Count)
                {
                    while (queueA.Count > 0 && result)
                    {
                        result = queueA.Dequeue() == queueB.Dequeue();
                    }
                }
                else
                {
                    result = false;
                }
                break;

            default: // String
                result = IsPalindrome(source);
                break;
        }

        return result;
    }

    private bool IsPalindrome(string source)
    {
        bool result = true;

        for (int i = 0; i < source.Length; i++)
        {
            int lastIndex = source.Length - 1 - i;
            result = source[i] == source[lastIndex];

            if (!result || i > lastIndex)
            {
                break;
            }
        }

        return result;
    }

    public int[] SortAscendent(int[] source)
    {
        int[] result = source;

        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result.Length; j++)
            {
                if (result[i] < result[j])
                {
                    int temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }

        return result;
    }

    public List<int> SortAscendent(List<int> source)
    {
        List<int> result = source;

        for (int i = 0; i < result.Count; i++)
        {
            for (int j = 0; j < result.Count; j++)
            {
                if (result[i] < result[j])
                {
                    int temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }

        return result;
    }

    public KeyValuePair<int, string> GetFromDictionary(Queue<int> queue, Stack<string> stack, int n)
    {
        KeyValuePair<int, string> result;

        if (queue.Count == stack.Count)
        {
            int i = 0;
            Dictionary<int, string> dict = FillDictionary(queue, stack);

            foreach (int key in dict.Keys)
            {
                if (i == n)
                {
                    result = new KeyValuePair<int, string>(key, dict[key]);
                }
                else
                {
                    i++;
                }
            }
        }

        return result;
    }

    private Dictionary<int, string> FillDictionary(Queue<int> sourceQueue, Stack<string> sourceStack)
    {
        Dictionary<int, string> result = new Dictionary<int, string>();

        while (sourceQueue.Count > 0)
        {
            result.Add(sourceQueue.Dequeue(), sourceStack.Pop());
        }

        return result;
    }

    public int GetFromStack(Stack<int> stack, int index)
    {
        int result = -1;

        do
        {
            result = stack.Pop();
            
        }
        while (stack.Count > index); //(stack.count - index)

        return result;
    }

    public void FillStackWithInts(Stack<int> stack, int size)
    {
        Random r = new Random();

        for (int i = 0; i < size; i++)
        {
            stack.Push(r.Next(1, 100));
        }
    }

    public int GetFromQueue(Queue<int> queue, int index)
    {
        int result = -1;
        int dequeuedElements = 0;        

        do
        {
            result = queue.Dequeue();
            dequeuedElements += 1; // dequeuedElements = dequeuedElements + 1 // dequeuedElements++
        }
        while (!(dequeuedElements > index)); // !(a > b) != [(a <= b) // (a < b) || (a == b)]

        return result;
    }

    public void FillQueueWithInts(Queue<int> queue, int size)
    {
        Random r = new Random();

        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(r.Next(1, 100));
        }
    }
}