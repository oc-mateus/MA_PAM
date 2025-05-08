using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace MA_PAM
{
    public static class ProdutoStorage
    {
        const string ProdutosKey = "ProdutosSalvos";

        // Salva a lista de produtos como JSON nas preferências
        public static void SalvarProdutos(List<Produto> produtos)
        {
            string json = JsonSerializer.Serialize(produtos);
            Preferences.Set(ProdutosKey, json);
        }

        // Carrega a lista de produtos das preferências
        public static List<Produto> CarregarProdutos()
        {
            string json = Preferences.Get(ProdutosKey, string.Empty);
            return string.IsNullOrEmpty(json)
                ? new List<Produto>()
                : JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }
    }
}
