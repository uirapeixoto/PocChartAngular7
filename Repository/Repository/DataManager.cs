using Repository.Domain;
using System;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class DataManager
    {
        public static List<ChartModel> GetData()
        {
            var r = new Random();
            return new List<ChartModel>
                {
                    new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data1" },
                    new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data2" },
                    new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data3" },
                    new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = "Data4" }
                };
        }

        public static List<ChartModel> GetData(int value)
        {
            var r = new Random();
            var l = new List<ChartModel>();

            for (int i = 0; i < value; i++)
            {
                l.Add(new ChartModel { Data = new List<int> { r.Next(1, 40) }, Label = $"Data{i + 1}" });
            }
            return l;
        }

        public static ChartModel GetOne(int value)
        {
            var r = new Random();

            var l = new List<ChartModel>();
            var n = new List<int>();

            for (int i = 0; i < value; i++)
            {
                n.Add(r.Next(1, 100));
            }

            return new ChartModel { Data = n, Label = $"Data{r.Next(1, 100)}" };

        }

        public static List<ChartModel> GetVariousData(int data, int amount)
        {
                
            var r = new Random();
            var l = new List<ChartModel>();
            var d = new List<int>();

            for (int j = 0; j < amount; j++)
            {
                for (int i = 0; i < data; i++)
                {
                    d.Add(r.Next(1, 100));
                }
                l.Add(new ChartModel { Data = d, Label = $"Data{j+1}" });
                d = new List<int>();
            }

            return l;
        }
    }
}