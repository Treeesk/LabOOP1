using System;

// файл для конфигурации дерева
class Program
{
    static void Main()
    {
        TreeNode root = new TreeNode(1);
        TreeNode b = new TreeNode(2);
        TreeNode c = new TreeNode(3);
        TreeNode d = new TreeNode(4);
        TreeNode e = new TreeNode(5);
        TreeNode f = new TreeNode(6);
        TreeNode g = new TreeNode(7);

        root.AddChild(b);
        root.AddChild(c);
        root.AddChild(d);

        b.AddChild(e);
        b.AddChild(f);

        d.AddChild(g);

        Console.WriteLine("Вывод дерева:");
        root.PrintTree();
    }
}