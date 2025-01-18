using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and their priorities in this order: soccer (5), history (4), workout (6)
    // Expected Result: Items are successfully added.
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Enqueue("soccer", 5);
            priorityQueue.Enqueue("history", 4);
            priorityQueue.Enqueue("workout", 6);
        }
        catch (AssertFailedException)
        {
            
            throw;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following items and their priorities in this order: soccer (5), history (4), workout (6)
    // Dequeue one item.
    // Expected Result: Item with the highest priority i.e workout should be returned.
    // Defect(s) Found: Did not get expected reslt. Item that was added first was dequeued instead of the item with the highest priority.
    // Fixed it by correcting loop condition to check all the items in the Dequeue function in "PriorityQueue.cs"
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        string ExpectedResult = "workout";
        
        priorityQueue.Enqueue("soccer", 5);
        priorityQueue.Enqueue("history", 4);
        priorityQueue.Enqueue("workout", 6);

        string ActiveItem = priorityQueue.Dequeue();
        Assert.AreEqual(ExpectedResult, ActiveItem);
    }

    [TestMethod]
    // Scenario: Create a queue with the following items and their priorities in this order: soccer (5), history (5), workout (2)
    // Dequeue one of the two items with the same highest priority
    // Expected Result: Item that was added first i.e soccer is dequeued.
    // Defect(s) Found: Did not get expected result. One of two items with highest priority that was added first was not dequeued as expected.
    // Fixed error by correcting if statement in Dequeue function that compares the priority of each item with that of the first in "PriorityQueue.cs"
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        string ExpectedResult = "soccer";
        
        priorityQueue.Enqueue("soccer", 5);
        priorityQueue.Enqueue("history", 5);
        priorityQueue.Enqueue("workout", 2);

        string ActiveItem = priorityQueue.Dequeue();
        Assert.AreEqual(ExpectedResult, ActiveItem);
    }

    [TestMethod]
    // Scenario: Call the dequeue function while the queue is empty.
    // Expected Result: An exception should be raised
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
    
    [TestMethod]
    // Scenario: Create a queue with 2 items, then call the Dequeue function more than 2 times.
    // Expected Result: Exception should be raised because queue would be empty before the third call of the Dequeue function.
    // Defect(s) Found: No exception was raised. The Dequeue method ran even though the queue was empty.
    // This error was caused because the Dequeue function did not remove anything from the queue before.
    // Fixed it by adding code to remove item at the start of the queue, or the item with the highest priority.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Enqueue("soccer", 5);
            priorityQueue.Enqueue("history", 4);
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

    }
}