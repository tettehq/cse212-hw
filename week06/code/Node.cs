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

        // return if value is equal to data in current node
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // return true if value is equal to the data in current node
        if (value == Data) {
            return true;
        }
        else
        {
            // check left subtree if value is less than data in current node
            if (value < Data)
            {
                if (Left is null)
                {
                    return false; // return false if left node is empty
                }
                else if (Left.Data != value)
                {
                    // recursive case:
                    // call Contains method again if data in left node is not equal to value
                    return Left.Contains(value);
                }
                else
                    return true;
            }
            // check right subtree if value is more than data in current node
            else{
                if (Right is null)
                {
                    return false; // return false if right node is empty
                }
                else if (Right.Data != value)
                {
                    // recursive case:
                    // call Contains method again if data in right node is not equal to value
                    return Right.Contains(value);
                }
                else
                    return true;
            }            
        }

    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (this is null)
            return 0; // base case: empty node adds 0 to the height
        
        int leftHeight = Left != null ? Left.GetHeight() : 0; // recursive case: add 0 to height if left node is empty, else recursively call GetHeight on Left node to determine its height
        int rightHeight = Right != null ? Right.GetHeight() : 0; // recursive case: add 0 to height if right node is empty, else recursively call GetHeight on Right node to determine its height

        return 1 + Math.Max(leftHeight, rightHeight); // add one to the max of left height and right height to get the height of the tree
    }
}