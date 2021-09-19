using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;
        public List<Detalle_de_Pedido> GetDetallePedidosPorId(int IdPedido)
        {
            List<Detalle_de_Pedido> detalle_De_Pedidos = null;
            try
            {
                DDetallePedido = new DDetallePedido();
                detalle_De_Pedidos = DDetallePedido.GetDetallePedidos(new Detalle_de_Pedido { Pedido = new Pedido { IdPedido = IdPedido } });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return detalle_De_Pedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<Detalle_de_Pedido> detalle_De_Pedidos = null;
            decimal total = 0;
            try
            {
                DDetallePedido = new DDetallePedido();
                detalle_De_Pedidos = DDetallePedido.GetDetallePedidos(new Detalle_de_Pedido { Pedido = new Pedido { IdPedido = IdPedido } });
           
                foreach(var item in detalle_De_Pedidos)
                {
                    total = total + item.Cantidad * item.PrecioUnidad - item.Descuento;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return total;
        }
    }
}
