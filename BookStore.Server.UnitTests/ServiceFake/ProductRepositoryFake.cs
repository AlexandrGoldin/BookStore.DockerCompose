using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.UnitTests.ServiceFake
{
    public class ProductRepositoryFake: IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepositoryFake()
        {
            _products = new List<Product>()
            {
                new Product(){
                    Id=1,Title="Происхождение",Author="Дэн Браун",Image="https://cv9.litres.ru/pub/c/elektronnaya-kniga/cover_330/27624091-den-braun-proishozhdenie.jpg",
                    Price=710.00m,Genre="Детектив",Rating=3,Description="Роберт Лэнгдон прибывает в музей Гуггенхайма" +
                    " в Бильбао по приглашению друга и бывшего студента Эдмонда Кирша. Миллиардер и компьютерный гуру," +
                    " он известен своими удивительными открытиями и предсказаниями. И этим вечером Кирш собирается" +
                    " «перевернуть все современные научные представления о мире», дав ответ на два главных вопроса," +
                    " волнующих человечество на протяжении всей истории:Откуда мы? Что нас ждет?"
                },
                new Product(){
                    Id = 2, Title = "1984", Author = "Джордж Оруэлл", Image = "https://cv5.litres.ru/pub/c/elektronnaya-kniga/cover_330/50397852--.jpg",
                    Price = 415.00m, Genre = "Фантастика", Rating = 5, Description = "Своеобразный антипод второй великой антиутопии XX века – «О дивный новый мир» Олдоса Хаксли." +
                    " Что, в сущности, страшнее: доведенное до абсурда «общество потребления» – или доведенное до абсолюта «общество идеи»? По Оруэллу," +
                    " нет и не может быть ничего ужаснее тотальной несвободы…"
                },
                new Product(){
                    Id = 3, Title = "Девушка в тумане", Author = "Донато Карризи", Image = "https://cv2.litres.ru/pub/c/elektronnaya-kniga/cover_330/27066425-donato-karrizi-devushka-v-tumane.jpg",
                    Price = 249.00m, Genre = "Детектив", Rating = 4, Description = "Затерянный в Альпах сонный городок, рождественский вечер," +
                " туман. От дома, где сияют огни елки и лежат подарки, до празднично украшенной местной церкви всего триста метров, " +
                "но в церкви юная Анна Лу так и не появилась… Вездесущие журналисты, фоторепортеры и телевизионщики осаждают городок. Каждый из них жаждет первым сообщить" +
                " сенсационные новости о ходе расследования."
                },
                new Product(){
                    Id = 4,
                    Title = "Зулейха открывает глаза",
                    Author = "Гузель Яхина",
                    Image = "https://cv8.litres.ru/pub/c/elektronnaya-kniga/cover_330/9527389-guzel-yahina-zuleyha-otkryvaet-glaza-9527389.jpg",
                    Price = 349.00m,
                    Genre = "Современная проза",
                    Rating = 5,
                    Description = "Роман «Зулейха открывает глаза» начинается зимой 1930 года в глухой татарской деревне. Крестьянку Зулейху вместе " +
                    "с сотнями других переселенцев отправляют в вагоне-теплушке по извечному каторжному маршруту в Сибирь.Дремучие крестьяне и ленинградские интеллигенты, деклассированный элемент " +
                    "и уголовники, мусульмане и христиане, язычники и атеисты, русские, татары, немцы, чуваши – все встретятся на берегах Ангары, ежедневно отстаивая у тайги и безжалостного " +
                    "государства свое право на жизнь."
                }
            };
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return _products;
        }
    }
}
