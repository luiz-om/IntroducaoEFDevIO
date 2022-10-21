

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
    if (teste ==1)
    {
        Console.WriteLine($"If quantidade de registros inseridos{teste} ");

    }
    else
    {
        Console.WriteLine($"Else quantidade de registros inseridos{teste} ");
    }

   
}

InserirProduto();
