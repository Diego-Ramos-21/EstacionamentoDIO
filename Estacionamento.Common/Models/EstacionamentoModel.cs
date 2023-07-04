using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Common.Models
{
    public class EstacionamentoModel
    {
        public decimal PriceDefault { get; set; }
        public decimal PriceByHour { get; set; }
        // Base de dados
        private List<string> cars = new List<string>();
        // CRUD
        public void Create(string car) => cars.Add(car);
        public List<string> GetCars() => cars;
        public string GetCarById(int id) => cars[id];
        /// <summary>
        /// Remove o carro da base de dados e informa o valor total a ser pago
        /// </summary>
        /// <param name="index">Identifica o carro a ser removido</param>
        /// <param name="spendTime">Informa o tempo gasto no estacionamento</param>
        /// <returns>Retorna o preço total a ser pago pelo cliente</returns>
        public decimal RemoveCar(int index, int spendTime)
        {
            cars.RemoveAt(index);
            return this.PriceDefault + (this.PriceByHour * spendTime);
        }
    }
}
