using ReductioAbsurdum;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Id = 1,
        Name = "Harry's Wand",
        Price = 12.99M,
        IsAvailable = false,
        ProductTypeId = "Wand",
        DateStocked = new DateTime(2023, 12, 14)
    },
    new Product()
    {
        Id = 2,
        Name = "Awry Potion",
        Price = 49.99M,
        IsAvailable = true,
        ProductTypeId = "Potion",
        DateStocked = new DateTime(2023, 11, 19)
    },
    new Product()
    {
        Id = 3,
        Name = "Ron's Shirt",
        Price = 23.99M,
        IsAvailable = true,
        ProductTypeId = "Apparel",
        DateStocked = new DateTime(2023, 09, 30)
    },
    new Product()
    {
        Id= 4,
        Name = "Magical Stick",
        Price = 59.99M,
        IsAvailable = true,
        ProductTypeId = "Enchanted Item",
        DateStocked = new DateTime(2023,04, 15)
    }
};

string greeting = @"Welcome to Reductio & Absurdum!
Providing high-quality magical supplies to the wizarding community for nearly 1,000 years!";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
        0. Exit
        1. View All Products
        2. View Products by Type
        3. Add Product to Inventory
        4. Delete Product From Inventory
        5. Update Product Details");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Thanks for visiting!");
    }
    else if (choice == "1")
    {
        ViewProductDetails();
    }
    else if (choice == "2")
    {
        TypeList();
    }
    else if (choice == "3")
    {
        AddProduct(products);
    }
    else if (choice == "4")
    {
        DeleteProduct();
    }
    else if (choice == "5")
    {
        UpdateProduct();
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

    Console.WriteLine($@"You chose: {chosenProduct.Name} of type {chosenProduct.ProductTypeId}. This item {(chosenProduct.IsAvailable ? $"has been in stock for {chosenProduct.DaysOnShelf} days and is available for ${chosenProduct.Price}!" : "has been sold.")}");
}

// create product
void AddProduct(List<Product> products)
{
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

void DeleteProduct()
{
    try
    {
        Console.WriteLine("Please choose a product you want to delete:");
        ListProducts();
        int selected = int.Parse(Console.ReadLine()) - 1;

        if (selected >= 0 && selected < products.Count)
        {
            Product deletedProduct = products[selected];
            products.RemoveAt(selected);
            Console.WriteLine($"{deletedProduct.Name} was succesfully deleted.");
        }
        else
        {
            Console.WriteLine("Error deleting. Please try again.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("There was an error. Please try again");
    }
}

void UpdateProduct()
{
    string choice = null;
    Console.WriteLine("Choose product to update:");
    ListProducts();

    try
    {
        Console.WriteLine("Enter the number of the product to update:");
        int selected = int.Parse(Console.ReadLine()) - 1;

        if (selected >= 0 && selected < products.Count)
        {
            Product selectedProduct = products[selected];
            Console.WriteLine($"You selected: {selectedProduct.Name} of type {selectedProduct.ProductTypeId}.");

            Console.WriteLine("Enter the new type for the product:");
            string newType = Console.ReadLine();
            selectedProduct.ProductTypeId = newType;

            Console.WriteLine($"{selectedProduct.Name}'s type has been updated to {selectedProduct.ProductTypeId}!");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please choose valid product!.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine($"There was an error. Please try again");
    }

}

void TypeList()
{
    string choice = null;
    while (choice != "0")
    {
        Console.WriteLine(@"Choose an option:
        0. Back to Menu
        1. View Potions
        2. View Wands
        3. View Apparel
        4. View Enchanted Items");

        choice = Console.ReadLine();
        if (choice == "0")
        {
            ViewProductDetails();
        }
        else if (choice == "1")
        {
            ViewPotions();
        }
        else if (choice == "2")
        {
            ViewWands();
        }
        else if (choice == "3")
        {
            ViewApparel();
        }
        else if (choice == "4")
        {
            ViewEnchantedItems();
        }
    }
}

void ViewEnchantedItems()
{
    var enchantedItems = products.Where(e => e.ProductTypeId == "Enchanted Item").ToList();

    Console.WriteLine("Enchanted Items:");

    try
    {
        foreach (var item in enchantedItems)
        {
            Console.WriteLine($"{item.Name} is {(item.IsAvailable ? $"available for {item.Price}!" : "sold.")}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("There was an error. Try again.");
    }
}

void ViewApparel()
{
    var apparel = products.Where(e => e.ProductTypeId == "Apparel").ToList();

    Console.WriteLine("Apparel:");

    try
    {
        foreach (var item in apparel)
        {
            Console.WriteLine($"{item.Name} is {(item.IsAvailable ? $"available for {item.Price}!" : "sold.")}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("There was an error. Try again.");
    }
}

void ViewPotions()
{
    var potion = products.Where(e => e.ProductTypeId == "Potion").ToList();

    Console.WriteLine("Potions:");

    try
    {
        foreach (var item in potion)
        {
            Console.WriteLine($"{item.Name} is {(item.IsAvailable ? $"available for {item.Price}!" : "sold.")}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("There was an error. Try again.");
    }
}

void ViewWands()
{
    var wand = products.Where(e => e.ProductTypeId == "Wand").ToList();

    Console.WriteLine("Wands:");

    try
    {
        foreach (var item in wand)
        {
            Console.WriteLine($"{item.Name} is {(item.IsAvailable ? $"available for {item.Price}!" : "sold.")}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("There was an error. Try again.");
    }
}