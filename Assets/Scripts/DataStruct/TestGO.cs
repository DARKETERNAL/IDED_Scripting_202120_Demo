using System.Collections.Generic;
using UnityEngine;

public class TestGO : MonoBehaviour
{
    private DataStructTester dataStructTester = new DataStructTester();

    // Start is called before the first frame update
    private void Start()
    {
        //print($"Array size: {dataStructTester.IntArray.Length}");
        //print($"List size: {dataStructTester.IntList.Count}");

        //PrintArray(dataStructTester.IntArray);

        //dataStructTester.FillCollections();

        //print($"Array size: {dataStructTester.IntArray.Length}");
        //print($"List size: {dataStructTester.IntList.Count}");

        //int[] sortedArray = dataStructTester.SortAscendent(dataStructTester.IntArray);
        //List<int> sortedList = dataStructTester.SortAscendent(dataStructTester.IntList);

        //PrintArray(sortedArray);
        //PrintArray(sortedList);

        //string palindrome = "ABBA";
        //string notPalindrome = "aniTalavalatina";
        //print($"{palindrome} is palindrome: {dataStructTester.IsPalindrome(palindrome, 2)}");
        //print($"{notPalindrome} is palindrome: {dataStructTester.IsPalindrome(notPalindrome, 2)}");

        Stack<string> stack = new Stack<string>();
        Queue<int> queue = new Queue<int>();

        FillQueue(queue);
        FillStack(stack);

        KeyValuePair<int, string> fromDict = dataStructTester.GetFromDictionary(queue, stack, 2);
        print($"Retrieved from dict: [{fromDict.Key}], [{fromDict.Value}]");
    }

    private void PrintArray(int[] source)
    {
        for (int i = 0; i < source.Length; i++)
        {
            print($"source[{i}]: {source[i]}");
        }
    }

    private void PrintArray(List<int> source)
    {
        for (int i = 0; i < source.Count; i++)
        {
            print($"source[{i}]: {source[i]}");
        }
    }

    private void FillQueue(Queue<int> queue, int size = 4)
    {
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Random.Range(1, 20));
        }
    }

    private void FillStack(Stack<string> stack)
    {
        stack.Push("anitalavalatina");
        stack.Push("murcielago");
        stack.Push("proximaclaseexamen");
        stack.Push("cualquierotracosa");
    }
}