using System;

public class TreeNode
{
    public int Value;
    public List<TreeNode> childs {get; set;}

    public TreeNode(int value)
    {
        Value = value;
        childs = new List<TreeNode>();
    }
    public void AddChild(TreeNode child)
    {
        childs.Add(child);
    }
    public void PrintTree()
    {
        Console.WriteLine(Value);

        if (childs.Count == 0)
            return;

        foreach (TreeNode child in childs)
        {
            child.PrintTree();
        }
    }
}

