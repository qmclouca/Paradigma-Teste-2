using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static IEnumerable<int> StringToIntList(string str)
    {
        if (String.IsNullOrEmpty(str))
        {
            yield break;
        }
        foreach (var value in str.Split(','))
        {
           if (int.TryParse(value, out int num))
                yield return num;
        }
    }

    public static void Main(string[] args)
    {
        int root = 0, rootIndex = 0;
        var input = Console.ReadLine();
        List<int> dataInput = StringToIntList(input).ToList();
        List<int> leftBranch = new List<int>();
        List<int> rightBranch = new List<int>();

        for (int x = 0; x < dataInput.Count; x++) {
        rerun:
            if (dataInput[x] > root)
            {
                root = dataInput[x];
                rootIndex = x;
                goto rerun;
            }
        }
        Console.WriteLine("root: {0}", root);
        // Console.WriteLine("index: {0}", rootIndex); //for test propouses only.

        for (int x = 0; x < rootIndex; x++)
        {
            leftBranch.Add(dataInput[x]);
        }
        for (int x = rootIndex+1; x < dataInput.Count; x++)
        {
            rightBranch.Add(dataInput[x]);
        }
        rerun1:
        for (int x = 0; x < leftBranch.Count-1; x++)
        {
            if (leftBranch[x] < leftBranch[x + 1])
            {
                int aux = leftBranch[x + 1];
                leftBranch[x + 1] = leftBranch[x];
                leftBranch[x] = aux;
                goto rerun1;
            }
        }
        rerun2:
        for (int x = 0; x < rightBranch.Count-1; x++)
        {
            if (rightBranch[x] < rightBranch[x + 1])
            {
                int aux = rightBranch[x + 1];
                rightBranch[x + 1] = rightBranch[x];
                rightBranch[x] = aux;
                goto rerun2;
            }
        }

        for (int x = 0; x < leftBranch.Count; x++){
            if (x == 0){
                Console.Write("Galhos da esquerda: {0}", leftBranch[x]);
            } else {
                Console.Write(", {0}", leftBranch[x]);
            }
        }
        Console.WriteLine();
        for (int x = 0; x < rightBranch.Count; x++){
            if (x == 0){
                Console.Write("Galhos da direita: {0}", rightBranch[x]);
            } else {
                Console.Write(", {0}", rightBranch[x]);
            }
        }
    }
}
