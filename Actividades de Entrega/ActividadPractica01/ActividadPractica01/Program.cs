
using ActividadPractica01.Domain;
using ActividadPractica01.Services;


ArticleManager am = new ArticleManager();
PaymentMethodManager pmm = new PaymentMethodManager();
ReceipManager receipManager = new ReceipManager();
DetailReceipManager detailReceipManager = new DetailReceipManager();

Article article = new Article()
{
    Name = "WebCam",
    Price = 800
};

PaymentMethod paymentMethod = new PaymentMethod()
{
    Method = "Paypal"
};

if (am.SaveArticle(article) && pmm.SavePaymentMethod(paymentMethod))
{
    DetailReceip detailReceip = new DetailReceip()
    {
        Article = am.GetArticleById(1),
        Amount = 2
    };

    Receip receip = new Receip()
    {
        Client = "Damian",
        PaymentMethod = pmm.GetPaymentMethodById(1),
    };

    receip.DetailsReceip.Add(detailReceip);

    if (receipManager.SaveReceip(receip))
    {
        Console.WriteLine("Factura generada con exito...");
    }
    else
    {
        Console.WriteLine("Error al generar la factura");
    }
}
else
{
    Console.WriteLine("No se pudo guardar el articulo...");
}
