using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NAudio.Wave;
using TagLib;


namespace Music.GlobalClass
{
    public class Monga
    {
        async Task GetDataFromMongoDB()
        {
            using (HttpClient client = new HttpClient())
            {
                // Замените URL на URL вашего сервера MongoDB и ваш конкретный запрос
                string apiUrl = "  url   ";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    // Обработка данных JSON, которые вы получили
                }
                else
                {
                    // Обработка ошибки
                }
            }
        }
    }
}
