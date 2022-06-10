using BuilderGenerator;
using System;
using System.Collections.Generic;
using System.Windows;
using static BuilderGenerator.NewsContent;

namespace Genkel_TP1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FinalBuilder politicNews;
        FinalBuilder sportNews;
        FinalBuilder economyNews;

        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }

        private Func<NewsContent> GetNews;

        private List<NewsTypes> newsTypes = new List<NewsTypes>() {NewsTypes.Политика,NewsTypes.Спорт,NewsTypes.Экономика, NewsTypes.Пусто };

        private void Initialization()
        {
            NewsType_CB1.ItemsSource = newsTypes;
            NewsType_CB2.ItemsSource = newsTypes;
            NewsType_CB3.ItemsSource = newsTypes;
            NewsType_CB1.SelectedItem = newsTypes[0];
            NewsType_CB2.SelectedItem = newsTypes[1];
            NewsType_CB3.SelectedItem = newsTypes[2];
        }

        private void ShowNews()
        {
            if (GetNews != null)
            {
                var content = GetNews();

                Output_TB.Text += $"{content.Header}\t{content.Date}\n\n{content.Title}\n\n";
            }
          
        }

        private void Clear()
        {
            Output_TB.Text = "";
        }

        private void ChooseNews(NewsTypes newsType)
        {
            if (newsType != NewsTypes.Пусто)
            {
                if (newsType == NewsTypes.Спорт)
                    GetNews = sportNews.Build;
                if (newsType == NewsTypes.Политика)
                    GetNews = politicNews.Build;
                if (newsType == NewsTypes.Экономика)
                    GetNews = economyNews.Build; 
            }
            else
                GetNews = null;
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            politicNews = Builder.GenerateNews("Политика", "ИЗРАИЛЬ: Предстоящий визит в Израиль федерального канцлера Германии Олафа Шольца оказался под угрозой срыва из-за трудового конфликта в израильском Министерстве иностранных дел.\n УКРАИНА: Президент Украины Владимир Зеленский заявил, что стране необходим глобальный документ с гарантиями безопасности. Об этом он сообщил в интервью 'РБК - Украина'.");
            sportNews = Builder.GenerateNews("Спорт", "ФИГУРНОЕ КАТАНИЕ: Тренер по фигурному катанию Этери Тутберидзе отреагировала на прокат произвольной программы Камилы Валиевой на Олимпиаде-2022. Валиева исполнила программу с ошибками и заняла 4 - е итоговое место(5 - е в произвольной).\n ХОККЕЙ: Сборная Финляндии по хоккею обыграла в полуфинале олимпийского турнира в Пекине команду Словакии. Встреча завершилась победой финнов со счетом 2:0. Подопечные Юкки Ялонена открыли счет в первом периоде.Точный бросок по воротам Патрика Рыбара нанес Сакари Маннинен(16 - я минута), которому ассистировали Петтери Линдбом и Сами Ватанен.");
            economyNews = Builder.GenerateNews("Экономика", "США: В США за последнее время зафиксирован самый стремительный рост потребительских цен за последние 40 лет. В декабре минувшего года цена на товары и услуги увеличились в годовом исчислении на 7%. Это самый высокий показатель с 1982 года.\nИТАЛИЯ: Италия ожидает сигналов разрядки украинского кризиса ото всех сторон, не только от России, однако обострение ситуации выглядело нарочным для удержания высоких цен на энергоресурсы, заявил РИА Новости председатель комиссии по иностранным делам сената итальянского парламента Вито Петрочелли.\n КИТАЙ: Китай положительно отреагировал на предложение Эквадора пересмотреть соглашение по долгу и отказаться от поставок нефти в счёт его погашения, сообщил президент Эквадора Гильермо Лассо.");

            politicNews.AddDate(DateTime.Now);
            
            Clear();
            ChooseNews((NewsTypes)NewsType_CB1.SelectedItem);
            ShowNews();

            ChooseNews((NewsTypes)NewsType_CB2.SelectedItem);
            ShowNews();

            ChooseNews((NewsTypes)NewsType_CB3.SelectedItem);
            ShowNews();
        }
    }
    public enum NewsTypes { Пусто, Спорт, Политика, Экономика}
}
