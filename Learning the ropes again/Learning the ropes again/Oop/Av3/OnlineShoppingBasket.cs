namespace Learning_the_ropes_again.Oop.Av3;

public class OnlineShoppingBasket
{
    private int articlesNum;
    private int[] price;
    private readonly int deliveryFee;

    public OnlineShoppingBasket()
    {
        articlesNum = 0;
        price = new int[50];
        deliveryFee = 0;
    }

    public OnlineShoppingBasket(int articlesNum, int[] price, int deliveryFee)
    {
        this.articlesNum = articlesNum;
        this.price = price;
        this.deliveryFee = deliveryFee;
    }

    public void AddArticle(int article)
    {
        price[articlesNum] = article;
        articlesNum++;
    }
    public void RemoveArticle()
    {
        price[articlesNum] = 0;
        articlesNum--;
    }

    public int ArticlesNum { get { return articlesNum; } }

    public static OnlineShoppingBasket operator +(OnlineShoppingBasket a, OnlineShoppingBasket b)
    {
        // Combine the price arrays into a new array
        int[] combinedPrices = new int[a.ArticlesNum + b.articlesNum];
        Array.Copy(a.price, 0, combinedPrices, 0, a.ArticlesNum);
        Array.Copy(b.price, 0, combinedPrices, a.ArticlesNum, b.articlesNum);

        return new OnlineShoppingBasket(
            a.ArticlesNum + b.articlesNum,
            combinedPrices,
            a.deliveryFee + b.deliveryFee
        );
    }

    public static OnlineShoppingBasket operator --(OnlineShoppingBasket a)
    {
        return new OnlineShoppingBasket(a.ArticlesNum - 1, a.price, a.deliveryFee);
    }
    public static bool operator ==(OnlineShoppingBasket l,  OnlineShoppingBasket r)
    {
        return (l.articlesNum == r.articlesNum && l.price.Sum() == r.price.Sum() && l.deliveryFee == r.deliveryFee);
    }

    public static bool operator !=(OnlineShoppingBasket l, OnlineShoppingBasket r)
    {
        return !(l == r);
    }

    public override string ToString()
    {
        return $"Articles ({this.ArticlesNum}): {Helper.Format(this.price, this.ArticlesNum)}, delivery: {this.deliveryFee}";
    }

    public static void RunSimpleDemo()
    {
        OnlineShoppingBasket a = new OnlineShoppingBasket();
        a.AddArticle(10);
        a.AddArticle(20);
        a.AddArticle(30);

        OnlineShoppingBasket b = new OnlineShoppingBasket(3, [30, 10, 20], 0);

        Helper.Print($"Shopping cart a: {a.ToString()}", ConsoleColor.DarkMagenta);
        Helper.Print($"Shopping cart b: {b.ToString()}", ConsoleColor.DarkMagenta);
        Helper.Print($"Are they equal? {a == b}", ConsoleColor.DarkMagenta);
        OnlineShoppingBasket c = a + b;
        Helper.Print($"Shopping cart combined articles number: {c.articlesNum}", ConsoleColor.Red);
        Helper.Print($"Added together: {(a + b).ToString()}", ConsoleColor.DarkMagenta);
        Helper.Print($"Added together: {c.ToString()}", ConsoleColor.DarkMagenta);
        c--;
        c.RemoveArticle();
        Helper.Print($"Added together: {c.ToString()}", ConsoleColor.DarkMagenta);
        
    }
}