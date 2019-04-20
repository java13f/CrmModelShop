using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class CashDesk
    {
        CrmContext context = new CrmContext();

        /// <summary>
        /// Номер кассы
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Продавец
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Очередь на кассе из корзин
        /// </summary>
        public Queue<Cart> Queue { get; set; }

        /// <summary>
        /// Максимальная очередь на кассе.
        /// Если очередь больше этого значения, то отказ клиенту
        /// </summary>
        public int MaxQueueLenght { get; set; } = 10;

        /// <summary>
        /// Счетчик клиентов которые ушли, потому что была превышена очередь на кассе
        /// </summary>
        public int ExitCustomer { get; set; }

        /// <summary>
        /// Флаг работы с моделью или базой данных.
        /// </summary>
        public bool IsModel { get; set; }

        public int Count => Queue.Count;

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }

        /// <summary>
        /// Добавление корзин в очередь
        /// </summary>
        /// <param name="cart"></param>
        public void Enqueue(Cart cart)
        {
            if (Queue.Count < MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        /// <summary>
        /// Извлечение корзин(товаров) из очереди
        /// </summary>
        public decimal Dequeue()
        {
            decimal sum = 0;

            if (Queue.Count == 0)
            {
                return 0;
            }

            var card = Queue.Dequeue();

            if (card != null)
            {
                var chek = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = card.Customer.CustomerId,
                    Customer = card.Customer,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    context.Checks.Add(chek);
                    context.SaveChanges();
                }
                else
                {
                    chek.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in card)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell()
                        {
                            CheckId = chek.CheckId,
                            Check = chek,
                            ProductId = product.ProductId,
                            Product = product
                        };
                        sells.Add(sell);

                        if (!IsModel)
                        {
                            context.Sells.Add(sell);
                        }
                        product.Count--;
                        sum += product.Price;
                    }
                }
                if (!IsModel)
                {
                    context.SaveChanges();
                }
            }
            return sum;
        }






    }
}
