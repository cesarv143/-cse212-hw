public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1


        if (value < Data)
        {
            
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    
    }
   
        // TODO Start Problem 2
            public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data && Left != null)
            return Left.Contains(value);

        if (value > Data && Right != null)
            return Right.Contains(value);

        return false;
    }
    

        // TODO Start Problem 4
       public int GetHeight()
    {
        // Obtenemos altura de hijos. Si no existen, su altura es 0.
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // La altura actual es 1 más el máximo de los dos subárboles
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
}