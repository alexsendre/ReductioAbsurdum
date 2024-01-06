using ReductioAbsurdum;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "wand 1",
        Price = 12.99M,
        IsAvailable = false,
        ProductTypeId = "Wand"
    },
    new Product()
    {
        Name = "Potion 1",
        Price = 49.99M,
        IsAvailable = true,
        ProductTypeId = "Potion"
    },
    new Product()
    {
        Name = "T-Shirt 1",
        Price = 23.99M,
        IsAvailable = true,
        ProductTypeId = "Apparel"
    }
};

string greeting = @"Welcome to Reductio & Absurdum!
Providing high-quality magical supplies to the wizarding community for nearly 1,000 years!";
Console.WriteLine(greeting);

string choice = null;
while(choice != "0")
{
    Console.WriteLine(@"Choose an option:
        0. Exit
        1. View All Products
        2. Add Product to Inventory
        3. Delete Product From Inventory
        4. Update Product Details");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Thanks for visiting!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        AddProduct(products);
    }
    else if (choice == "3")
    {
        Console.WriteLine("Option 3");
    }
    else if (choice == "4")
    {
        ViewProductDetails();
    }
}

void ListProducts()
{
    Console.WriteLine("Products: ");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewProductDetails()
{
    ListProducts();
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please choose a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Integers only please!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose only exisiting items.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Error. Please try again.");
        }
    }

    Console.WriteLine($@"You chose: {chosenProduct.Name} of type {chosenProduct.ProductTypeId}. This item {(chosenProduct.IsAvailable ? $"is available for ${chosenProduct.Price}!" : "has been sold.")}");
}

// create product
void AddProduct(List<Product> products)
{
    /*
     when chosen from menu, user will be prompted to enter the name, price, and type of product to the pre-existing list of products.
     */

    Console.WriteLine("Enter Product Name: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter Price Value of your Item: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Enter Type of Product: ");
    string type = Console.ReadLine();

    Product createdProduct = new Product();
    createdProduct.Name = name;
    createdProduct.Price = price;
    createdProduct.ProductTypeId = type;

    products.Add(createdProduct);
    Console.WriteLine($"\nNice! {name} was added successfully.\n");
}