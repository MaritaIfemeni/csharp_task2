/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
    if (jaggedArray.Length == 0)
    {
        return new int[0];
    }

    var commonElements = jaggedArray.Aggregate((current, next) => current.Intersect(next).ToArray());
    return commonElements;
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
/* write method to print arr1Common */

void PrintArray(int[] arr)
{
    foreach (int item in arr)
    {
        Console.WriteLine(item);
    }
}
PrintArray(arr1Common);


/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        Array.Reverse(jaggedArray[i]);
        Console.WriteLine(string.Join(", ", jaggedArray[i]));
    }

}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
/* write method to print arr2 */



/* 
Challenge 3.Find the difference between 2 consecutive elements of an array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
 */
void CalculateDiff(int[][] jaggedArray)
{

    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] innerArray = jaggedArray[i];
        int[] diffArray = new int[innerArray.Length - 1];

        for (int j = 0; j < innerArray.Length - 1; j++)
        {
            diffArray[j] = innerArray[j] - innerArray[j + 1];
        }

        jaggedArray[i] = diffArray;
        Console.WriteLine(string.Join(", ", jaggedArray[i]));
    }

}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);
/* write method to print arr3 */


/* 
Challenge 4. Inverse column/row of a rectangular array.
For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
Expected result: {{1,4},{2,5},{3,6}}
 */
int[,] InverseRec(int[,] recArray)
{
    int rows = recArray.GetLength(0);
    int cols = recArray.GetLength(1);
    int[,] inverseArray = new int[cols, rows];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            inverseArray[j, i] = recArray[i, j];
        }
    }

    return inverseArray;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
/* write method to print arr4Inverse */

void Print2DArray(int[,] arr)
{
    int rows = arr.GetLength(0);
    int cols = arr.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
    }
}

Print2DArray(arr4Inverse);

/* 
Challenge 5. Write a function that accepts a variable number of params of any of these types: 
string, number. 
- For strings, join them in a sentence. 
- For numbers then sum them up. 
- Finally print everything out. 
Example: Demo("hello", 1, 2, "world") 
Expected result: hello world; 3 */
void Demo(params object[] args)
{
    string sentence = "";
    int sum = 0;

    foreach (object arg in args)
    {
        if (arg is string)
        {
            sentence += arg.ToString() + " ";
        }
        else if (arg is int)
        {
            sum += (int)arg;
        }
    }

    sentence = sentence.Trim();
    Console.WriteLine($"{sentence}; {sum}");
}

Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
static void SwapTwo<T>(ref T obj1, ref T obj2)
{
    if (obj1.GetType() == obj2.GetType())
    {
        if (obj1 is string && ((string)(object)obj1).Length > 5 && ((string)(object)obj2).Length > 5)
        {
            T temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
        else if (obj1 is int && (int)(object)obj1 > 18 && (int)(object)obj2 > 18)
        {
            T temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
        else
        {
            Console.WriteLine("No Swapping");
        }
    }
    else
    {
        Console.WriteLine("Objects are not of the same type.");
    }
}


/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random random = new Random();
    int randomNumber = random.Next(1, 101); // Generate a random number between 1 and 100

    int guess;
    do
    {
        Console.Write("Guess a nymber I am thinking: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out guess))
        {
            if (guess == randomNumber)
            {
                Console.WriteLine("This was right.");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("This is too low.");
            }
            else
            {
                Console.WriteLine("This is too high.");
            }
        }
        else
        {
            Console.WriteLine("Invalid, give only numbers.");
        }

    } while (guess != randomNumber);
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
Console.WriteLine(subCart);

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Price: {Price}, Quantity: {Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    public OrderItem this[int index]
    {
        get { return _cart[index]; }
    }

    public List<OrderItem> this[int startIndex, int endIndex]
    {
        get { return _cart.GetRange(startIndex, endIndex - startIndex + 1); }
    }

    public void AddToCart(params OrderItem[] items)
    {
        foreach (var item in items)
        {
            var existingItem = _cart.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item);
            }
        }
    }

    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
        totalPrice = _cart.Sum(item => item.Price * item.Quantity);
        totalQuantity = _cart.Sum(item => item.Quantity);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _cart.Select(item => $"Id: {item.Id}, Price: {item.Price}, Quantity: {item.Quantity}"));
    }
}