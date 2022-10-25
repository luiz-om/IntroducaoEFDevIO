

using CursoEFCore.Data;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

static void InserirProduto()
{
    //declaração para criar uma instância  produto
    var produto = new Produto
    {
        Descricao = "Produto Teste",
        CodigoBarras = "123455646411",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true

    };

    using var db = new ApplicationContext();
    //db.Entry(produto).State = EntityState.Added;
    //db.Set<Produto>().Add(produto);
    //db.Add(produto);
    db.Produtos.Add(produto);

    var teste = db.SaveChanges();
    if (teste == 1)
    {
        Console.WriteLine($"If quantidade de registros inseridos{teste} ");

    }
    else
    {
        Console.WriteLine($"Else quantidade de registros inseridos{teste} ");
    }


}
static void InserirDadosEmMassa()
{
    //declaração para criar uma instância  produto
    var produto = new Produto
    {
        Descricao = "Produto Teste",
        CodigoBarras = "123455646411",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true

    };

    var cliente = new Cliente
    {
        Nome = "Luiz Fernando",
        CEP = "79011210",
        Cidade = "Campão",
        Estado =  "MS",
        Telefone = "67998153415"
    };

    var testeLista = new[]
    {
        new Cliente
        {
             Nome = "Luiz Fernando3",
        CEP = "79011210",
        Cidade = "Campão",
        Estado =  "MS",
        Telefone = "67998153415"
        },new Cliente
        {
             Nome = "Luiz Fernando4",
        CEP = "79011210",
        Cidade = "Campão",
        Estado =  "MS",
        Telefone = "67998153415"
        }
    };

    using var db = new ApplicationContext();
    // Insere varios registros tanto separados ou uma lista.
    db.AddRange(cliente, produto);

    var registros = db.SaveChanges();
    Console.WriteLine($"Total de Registro(s): {registros}");


}
static void ConsultaDados()
{
    using var db = new ApplicationContext();

    //Consulta por sintaxe 
  //  var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
    //Consulta por metodos
    var consultaPorMetodo =  db.Clientes.Where(p => p.Id > 0 ).ToList();

    foreach( var clientes in consultaPorMetodo)
    {
        //Estudar Metodos LINQ
        Console.WriteLine($"Consultado Cliente {clientes.Id}");
        //Clientes.Find(clientes.Id);
        db.Clientes.FirstOrDefault(p => p.Id == clientes.Id);


    }

}
//InserirProduto();
//InserirDadosEmMassa();

ConsultaDados();
