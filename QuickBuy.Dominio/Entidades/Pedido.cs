﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public Pedido()
        {
        }

        public int Id { get; set; }

        public  DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EndereçoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public IFormatProvider FormaPagamento { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um item de pedido
        /// ou muitos itens de  pedidos
        /// </summary>

        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
            AdicionarCritica("Critica - Pedido nao pode ficar sem item de pedido");
            
            if (string.IsNullOrEmpty(CEP))
            AdicionarCritica("Critica - CEP deve estar preenchido");
        }
    }
}
