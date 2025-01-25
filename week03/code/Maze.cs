/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        var coordinates = (_currX, _currY); // create a variable to store current coordinates as a ValueTuple.

        // using the coordinates as a key, check the maze dictionary value to
        // see if a left movement is possible from the possible moves array it stores
        if (_mazeMap[coordinates][0])
        {
            _currX -= 1; // create a left movement action by reducing "_currX" by 1
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        var coordinates = (_currX, _currY); // create a variable to store current coordinates as a ValueTuple.

        // using the coordinates as a key, check the maze dictionary value to
        // see if a right movement is possible from the possible moves array it stores
        if (_mazeMap[coordinates][1])
        {
            _currX += 1; // create a left movement action by incrementing "_currX" by 1
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        var coordinates = (_currX, _currY); // create a variable to store current coordinates as a ValueTuple.
        
        // using the coordinates as a key, check the maze dictionary value to
        // see if an up movement is possible from the possible moves array it stores
        if (_mazeMap[coordinates][2])
        {
            _currY -= 1; // create an up movement action by reducing "_currY" by 1
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        var coordinates = (_currX, _currY); // create a variable to store current coordinates as a ValueTuple.
        
        // using the coordinates as a key, check the maze dictionary value to
        // see if a down movement is possible from the possible moves array it stores
        if (_mazeMap[coordinates][3])
        {
            _currY += 1; // create a down movement action by incrementing "_currY" by 1
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}