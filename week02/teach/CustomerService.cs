/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: set the maximum size to -5 to see if it defaults to 10
        // Expected Result: the maximum size is reset to 10.
        // Console.WriteLine("Test 1");
        var checkSize = new CustomerService(-5);
        var max = checkSize._maxSize;
        if (max == 10) {
            Console.WriteLine($"Max size is reset to {max}");
        }
        else {
            Console.WriteLine("Max size not reset properly");
            return;
        }

        // Defect(s) Found: None

        // Console.WriteLine("=================");

        // Test 2
        // Scenario: Adding two new customer to the queue and and check if the queue size is two
        // Expected Result: Returns the number of customers as two.
        Console.WriteLine("Test 2");
        cs = new CustomerService(10);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        var size = cs._queue.Count;
        if (size == 2) {
            Console.WriteLine($"Customers successfully queued. There are {size} customers.");
        }
        else {
            Console.WriteLine("Error in queuing customers.");
            return;
        }
        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Adding an extra customer to the queue when the queue is full.
        // Expected Result: Returns an error message indicating that queue has exceeded capacity
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        
        // Defect(s) Found: No error is display when extra customers are added while queue is full. Fixed this by changing ">" to ">=" in AddNewCustomer if block. Ln 103.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Calling the ServeCustomer function to dequeue the customers.
        // Expected Result: Customers are dequeued in order and their info displayed.
        Console.WriteLine("Test 4");
        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.ServeCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: Code removes the customer from the queue before trying to display the info, so the info of the dequeued customer cannot be viewed.
        // Fixed by putting the line of code that removes the customer below the one that displays customer info.
        
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serving a customer while the queue is empty.
        // Expected Result: An error message indicating that queue is empty.
        Console.WriteLine("Test 5");
        cs = new CustomerService(4);
        cs.ServeCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: This found that I need to check the length in serve_customer and display an error message

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) { // changed ">" to ">=" to ensure customers cannot be added when queue is full.
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count > 0) // Added an if statement that checks if there is any customer in the queue before attempting to serve the player.
        {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0); // Defect fixed by bring this line below in the function to ensure that customer info is displayed before being dequeued.
        }
        else {
            Console.WriteLine("There are no customers to serve.");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}