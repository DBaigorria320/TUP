using Ejercicio1_6_U1.Domain;
using Ejercicio1_6_U1.Services;

TypeAccount ta1 = new TypeAccount()
{
    Name = "Caja de Ahorro en Pesos"
};

TypeAccount ta2 = new TypeAccount()
{
    Name = "Caja de Ahorro en Dolares"
};

TypeAccount ta3 = new TypeAccount()
{
    Name = "Caja de Ahorro en Euros"
};

TypeAccountServices taServices = new TypeAccountServices();

taServices.SaveTypeAccount(ta1);
taServices.SaveTypeAccount(ta2);
taServices.SaveTypeAccount(ta3);

Client client = new Client()
{
    Name = "Damian",
    Surname = "Baigorria",
    Dni = "42691639"
};
ClientServices clientServices = new ClientServices();

Account account = new Account()
{
    Cbu = "1234",
    Balance = 2000,
    TypeAccount = taServices.GetTypeAccountById(3),
    LastMovement = "Crear cuenta"
};

client.Accounts.Add(account);

if (clientServices.SaveClient(client))
{
    Console.WriteLine("Cliente añadido correctamente con su cuenta");
}
else
{
    Console.WriteLine("Error");
}
