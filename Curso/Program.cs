

using CursoEFCore.Data;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        var cc =db.Clientes.FirstOrDefault(p => p.Id == clientes.Id);
        Console.WriteLine(cc);


    }

}
static void CadastrarPedido()
{
    using var db = new ApplicationContext();

    var cliente = db.Clientes.FirstOrDefault(p => p.Id == 2);
    var produto = db.Produtos.FirstOrDefault();

    var pedido = new Pedido {
        ClienteId = cliente.Id,
        IniciadoEm = DateTime.Now,
        FinalizadoEm = DateTime.Now,
        Observacao = "Pedido Teste2",
        Status = StatusPedido.Analise,
        TipoFrete = TipoFrete.SEMFRETE,
        Itens = new List<PedidoItem>
        {
            new PedidoItem
            {
                ProdutoId = produto.Id,
                Desconto = 0,
                Quantidade = 1,
                Valor = 10,
            }
        }
    };
    db.Pedidos.Add(pedido);

    db.SaveChanges();
    

}
//InserirProduto();
//InserirDadosEmMassa();
//ConsultaDados();
//CadastrarPedido();
ConsultarPedidoCarregamentoAdiantado();

static void ConsultarPedidoCarregamentoAdiantado()
{
    using var db = new ApplicationContext();
    var pedidos = db.Pedidos
        .Include(p=> p.Itens)
        .ThenInclude(p => p.Produto)
        .ToList();

Console.WriteLine(pedidos.Count);


}
