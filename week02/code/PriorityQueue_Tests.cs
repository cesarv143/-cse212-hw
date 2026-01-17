using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Dequeue should return "High".
    // Defect(s) Found: Original code did not remove item from queue after Dequeue.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue two items with same priority.
    // Expected Result: Dequeue should return "First" (FIFO).
    // Defect(s) Found: Original code returned "Second" because it used >= instead of >.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None, exception was thrown correctly.
    public void TestPriorityQueue_Empty()
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
    }

    [TestMethod]
    // Scenario: Multiple dequeues until queue is empty.
    // Expected Result: Items removed in correct priority order: B, C, A.
    // Defect(s) Found: Original code did not remove items, so queue never emptied.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // highest priority
        Assert.AreEqual("C", priorityQueue.Dequeue()); // next highest
        Assert.AreEqual("A", priorityQueue.Dequeue()); // last

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}